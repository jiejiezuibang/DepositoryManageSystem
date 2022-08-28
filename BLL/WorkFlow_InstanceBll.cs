using Common.ResultEnums;
using IDepositoryDal;
using Sister;
using Sister.Dtos.WorkFlow_Instance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IDepositoryBll;
using Sister.Dtos.WorkFlow_InstanceStep;

namespace BLL
{
    public class WorkFlow_InstanceBll : IWorkFlow_InstanceBll
    {
        // 构建工作流实例dal对象
        private readonly IWorkFlow_InstanceDal _workFlow_InstanceDal;
        // 构建工作流模板dal对象
        private readonly IWorkFlow_ModelDal _workFlow_ModelDal;
        // 构建耗材信息dal对象
        private readonly IConsumableInfoDal _consumableInfoDal;
        // 构建部门信息dal对象
        private readonly IDepartmentInfoDal _departmentInfoDal;
        // 构建用户信息dal对象
        private readonly IUserInfoDal _userinfoDal;
        // 构建工作流步骤dal对象
        private readonly IWorkFlow_InstanceStepDal _workFlow_InstanceStepDal;
        // 构建用户角色dal对象
        private readonly IR_UserInfo_RoleInfoDal _r_UserInfo_RoleInfoDal;
        // 构建数据库上下文对象
        private readonly DepositoryContext _depositoryContext;
        // 构建角色信息dal对象
        private readonly IRoleInfoDal _roleInfoDal;
        public WorkFlow_InstanceBll(IWorkFlow_InstanceDal workFlow_InstanceDal,
            IWorkFlow_ModelDal workFlow_ModelDal,
            IConsumableInfoDal consumableInfoDal,
            IUserInfoDal userInfoDal,
            IDepartmentInfoDal departmentInfoDal,
            IWorkFlow_InstanceStepDal workFlow_InstanceStepDal,
            IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal,
            IRoleInfoDal roleInfoDal,
            DepositoryContext depositoryContext)
        {
            this._workFlow_InstanceDal = workFlow_InstanceDal;
            this._workFlow_ModelDal = workFlow_ModelDal;
            this._consumableInfoDal = consumableInfoDal;
            this._userinfoDal = userInfoDal;
            this._departmentInfoDal = departmentInfoDal;
            this._workFlow_InstanceStepDal = workFlow_InstanceStepDal;
            this._r_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
            this._depositoryContext = depositoryContext;
            this._roleInfoDal = roleInfoDal;
        }
        /// <summary>
        /// 添加工作流实例信息业务
        /// </summary>
        /// <param name="addWorkFlow_InstanceDto"></param>
        /// <returns></returns>
        public WorkFlow_InstanceEnums AddWorkFlow_InstanceBll(AddWorkFlow_InstanceDto addWorkFlow_InstanceDto,out string msg)
        {
            using(var dbTransaction = _depositoryContext.Database.BeginTransaction())
            {
                try
                {
                    // 判断用户是否存在
                    UserInfo userInfo = _userinfoDal.GetAll().FirstOrDefault(u => u.Id.Equals(addWorkFlow_InstanceDto.Creator));
                    if (userInfo == null)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "登录信息获取失败";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }
                    // 判断模板是否存在
                    if (addWorkFlow_InstanceDto.ModelId == null || _workFlow_ModelDal.GetAll().Find(addWorkFlow_InstanceDto.ModelId) == null)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "查询不到对应模板";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }


                    WorkFlow_Instance workFlow_Instance = new WorkFlow_Instance()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ModelId = addWorkFlow_InstanceDto.ModelId,
                        Status = WorkFlow_InstanceStatusEnum.审核中,
                        Description = addWorkFlow_InstanceDto.Description,
                        Reason = addWorkFlow_InstanceDto.Reason,
                        CreateTime = DateTime.Now,
                        Creator = addWorkFlow_InstanceDto.Creator,
                        OutNum = addWorkFlow_InstanceDto.OutNum,
                        OutGoodsId = addWorkFlow_InstanceDto.OutGoodsId,
                    };
                    // 添加工作流实例信息
                    if (!_workFlow_InstanceDal.AddAsync(workFlow_Instance).Result)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "添加工作流实例信息失败";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }

                    // 通过用户信息获取到对应部门
                    var departmentInfo = _departmentInfoDal.GetAll().FirstOrDefault(d => d.Id.Equals(userInfo.DepartmentId));
                    if (departmentInfo == null)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "没有查询到对应的部门主管";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }

                    // 判断当前领导是否拥有部门领导角色
                    int Count = (from a in _r_UserInfo_RoleInfoDal.GetAll().Where(r => r.UserId.Equals(departmentInfo.LeaderId))
                                 join b in _roleInfoDal.GetAll().Where(r => r.RoleName.Equals("部门经理") && !r.IsDelete)
                                 on a.RoleId equals b.Id
                                 select b.RoleName).Count();
                    if (Count <= 0)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "当前部门领导不是部门经理角色";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }



                    WorkFlow_InstanceStep workFlow_InstanceStep = new WorkFlow_InstanceStep()
                    {
                        Id = Guid.NewGuid().ToString(),
                        InstanceId = workFlow_Instance.Id,
                        ReviewerId = departmentInfo.LeaderId,
                        ReviewStatus = WorkFlow_InstanceStepStatusEnums.审核中,
                        CreateTime = DateTime.Now,
                    };
                    if (!_workFlow_InstanceStepDal.AddAsync(workFlow_InstanceStep).Result)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "工作流步骤添加失败";
                        return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                    }
                    msg = "工作流实例添加成功";
                    // 提交事务
                    dbTransaction.Commit();
                    return WorkFlow_InstanceEnums.AddWorkFlow_InstanceSuccess;
                }
                catch (Exception)
                {
                    // 回滚
                    dbTransaction.Rollback();
                    msg = "添加实例失败，发生不知名错误，请稍后再试";
                    return WorkFlow_InstanceEnums.AddWorkFlow_InstanceError;
                }
            }
            


        }
        /// <summary>
        /// 获取工作流实例信息全部数据业务
        /// </summary>
        /// <param name="findWorkFlow_InstanceDto"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<WorkFlow_InstanceDto> GetShowWorkFlow_InstanceBll(FindWorkFlow_InstanceDto findWorkFlow_InstanceDto, out int Count)
        {
            var workFlow_InstanceDtos = (from a in _workFlow_InstanceDal.GetAll()
                                         .Where(w => w.Creator.Equals(findWorkFlow_InstanceDto.userId))
                                         join b in _workFlow_ModelDal.GetAll()
                                         on a.ModelId equals b.Id
                                         into abJoin
                                         from bData in abJoin.DefaultIfEmpty()
                                         join c in _consumableInfoDal.GetAll()
                                         on a.OutGoodsId equals c.Id
                                         into acJoin
                                         from cData in acJoin.DefaultIfEmpty()
                                         join d in _userinfoDal.GetAll()
                                         on a.Creator equals d.Id
                                         into adJoin
                                         from dData in adJoin.DefaultIfEmpty()
                                         select new WorkFlow_InstanceDto
                                         {
                                             Id = a.Id,
                                             ModelName = bData.Title,
                                             Status = a.Status.ToString(),
                                             Description = a.Description,
                                             Reason = a.Reason,
                                             CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
                                             Creator = dData.UserName,
                                             OutNum = a.OutNum,
                                             OutGoodsName = cData.ConsumableName
                                         });

            Count = workFlow_InstanceDtos.Count();

            return workFlow_InstanceDtos.Skip(findWorkFlow_InstanceDto.limit * (findWorkFlow_InstanceDto.page - 1)).Take(findWorkFlow_InstanceDto.limit).ToList();
        }

    }
}
