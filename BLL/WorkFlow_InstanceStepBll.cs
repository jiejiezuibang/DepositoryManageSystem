using IDepositoryDal;
using Sister.Dtos.WorkFlow_InstanceStep;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IDepositoryBll;
using Common.ResultEnums;
using Sister;
using System.Threading.Tasks;
using Sister.Dtos.WorkFlow_Instance;
using Sister.Dtos.ConsumableRecord;

namespace BLL
{
    public class WorkFlow_InstanceStepBll: IWorkFlow_InstanceStepBll
    {
        // 构建工作流步骤dal
        private readonly IWorkFlow_InstanceStepDal _workFlow_InstanceStepDal;
        // 构建工作流模板dal
        private readonly IWorkFlow_ModelDal _workFlow_ModelDal;
        // 构建工作流实例dal
        private readonly IWorkFlow_InstanceDal _workFlow_InstanceDal;
        // 构建用户管理dal
        private readonly IUserInfoDal _userInfoDal;
        // 构建耗材管理dal
        private readonly IConsumableInfoDal _consumableInfoDal;
        // 构建角色dal
        private readonly IRoleInfoDal _roleInfoDal;
        // 构建用户角色dal
        private readonly IR_UserInfo_RoleInfoDal _iR_UserInfo_RoleInfoDal;
        // 构建数据库上下文dal
        private readonly DepositoryContext _depositoryContext;
        // 构建耗材记录dal
        private readonly IConsumableRecordDal _consumableRecordDal;
        public WorkFlow_InstanceStepBll(
            IWorkFlow_InstanceStepDal workFlow_InstanceStepDal,
            IWorkFlow_InstanceDal workFlow_InstanceDal,
            IWorkFlow_ModelDal workFlow_ModelDal,
            IUserInfoDal userInfoDal,
            IConsumableInfoDal consumableInfoDal,
            IRoleInfoDal roleInfoDal,
            IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal,
            DepositoryContext depositoryContext,
            IConsumableRecordDal consumableRecordDal)
        {
            this._workFlow_InstanceStepDal = workFlow_InstanceStepDal;
            this._workFlow_InstanceDal = workFlow_InstanceDal;
            this._workFlow_ModelDal = workFlow_ModelDal;
            this._userInfoDal = userInfoDal;
            this._consumableInfoDal = consumableInfoDal;
            this._roleInfoDal = roleInfoDal;
            this._iR_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
            this._depositoryContext = depositoryContext;
            this._consumableRecordDal = consumableRecordDal;
        }
        /// <summary>
        /// 获取要展示的工作流步骤信息业务
        /// </summary>
        /// <param name="findWorkFlow_InstanceStepDto"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<WorkFlow_InstanceStepDto> GetShowWorkFlow_InstanceStepBll(FindWorkFlow_InstanceStepDto findWorkFlow_InstanceStepDto,out int Count)
        {
            // 获取要展示的步骤数据
            var data = from a in _workFlow_InstanceStepDal.GetAll()
                       .Where(w => w.ReviewerId.Equals(findWorkFlow_InstanceStepDto.UserId)) // 审核人必须等于登录人Id
            join b in _workFlow_InstanceDal.GetAll() // 连实例表
            on a.InstanceId equals b.Id
            into abJoin
            from bData in abJoin.DefaultIfEmpty()

            join c in _workFlow_ModelDal.GetAll().Where(w => !w.IsDelete)   // 连模板表
            on bData.ModelId equals c.Id
            into bcJoin
            from cData in bcJoin.DefaultIfEmpty()

            join d in _userInfoDal.GetAll().Where(u => !u.IsDelete) // 连用户表
            on a.ReviewerId equals d.Id
            into adJoin
            from dData in adJoin.DefaultIfEmpty()

            join e in _consumableInfoDal.GetAll().Where(c => !c.IsDelete)   // 连耗材表
            on bData.OutGoodsId equals e.Id
            into ebJoin
            from eData in ebJoin.DefaultIfEmpty()

            join f in _userInfoDal.GetAll().Where(u => !u.IsDelete) // 连用户表
            on bData.Creator equals f.Id
            into fbJoin
            from fData in fbJoin.DefaultIfEmpty()

            select new
            {
                Id = a.Id,
                Title = cData.Title,
                ConsumableName = eData.ConsumableName,
                OutNum = bData.OutNum,
                CreatorName = fData.UserName,   // 添加人名称
                ReviewerName = dData.UserName,  // 审核人名称
                ReviewStatus = a.ReviewStatus,
                Reason = bData.Reason,  // 申请理由
                ReviewReason = a.ReviewReason,  // 审核理由
                ReviewTime = a.ReviewTime,
                CreateTime = a.CreateTime,
            };

            // 总条数
            Count = data.Count();

            // 分页
            return data.Skip(findWorkFlow_InstanceStepDto.limit * (findWorkFlow_InstanceStepDto.page - 1))
                .Take(findWorkFlow_InstanceStepDto.limit)
                .ToList()
                .Select(s => new WorkFlow_InstanceStepDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    ConsumableName = s.ConsumableName,
                    OutNum = s.OutNum,
                    CreatorName = s.CreatorName,   // 添加人名称
                    ReviewerName = s.ReviewerName,  // 审核人名称
                    ReviewStatus = s.ReviewStatus.ToString(),
                    Reason = s.Reason,  // 申请理由
                    ReviewReason = s.ReviewReason,  // 审核理由
                    ReviewTime = s.ReviewTime == null?"": s.ReviewTime.GetValueOrDefault().ToString("yyyy-MM-dd HH-mm-ss"),
                    CreateTime = s.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
                }).ToList();
        }
        /// <summary>
        /// 通过Id查询对应的工作流步骤信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GetEditWorkFlow_InstanceStepDto FindWorkFlow_InstanceStepBll(string Id)
        {
            return (from a in _workFlow_InstanceStepDal.GetAll().Where(w => w.Id.Equals(Id))
            join b in _workFlow_InstanceDal.GetAll()
            on a.InstanceId equals b.Id
            into abJoin
            from bData in abJoin.DefaultIfEmpty()

            join c in _userInfoDal.GetAll().Where(u => !u.IsDelete)
            on bData.Creator equals c.Id
            into cbJoin
            from cData in cbJoin.DefaultIfEmpty()

            join d in _consumableInfoDal.GetAll().Where(c => !c.IsDelete)
            on bData.OutGoodsId equals d.Id
            into dbJoin
            from dData in dbJoin.DefaultIfEmpty()

            join e in _iR_UserInfo_RoleInfoDal.GetAll()  // 连用户角色表
            on a.ReviewerId equals e.UserId
            into ecJoin
            from eData in ecJoin.DefaultIfEmpty()

            join f in _roleInfoDal.GetAll().Where(r => !r.IsDelete) // 连角色表
            on eData.RoleId equals f.Id
            into feJoin
            from fData in feJoin.DefaultIfEmpty()

            select new GetEditWorkFlow_InstanceStepDto
            {
                Id = a.Id,
                CreatorName = cData.UserName,
                ConsumableName = dData.ConsumableName,
                OutNum = bData.OutNum,
                Reason = bData.Reason,
                RoleName = fData.RoleName
            }).FirstOrDefault();

        }
        /// <summary>
        /// 审核业务(更新工作流步骤)
        /// </summary>
        public WorkFlow_InstanceStepEnums EidtWorkFlow_InstanceStepBll(EidtWorkFlow_InstanceStepDto eidtWorkFlow_InstanceStepDto,out string msg)
        {
            using(var dbTransaction = _depositoryContext.Database.BeginTransaction())
            {
                try
                {
                    // 校验数据
                    if (string.IsNullOrEmpty(eidtWorkFlow_InstanceStepDto.ReviewReason))
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "审核理由不能为空";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    if (string.IsNullOrEmpty(eidtWorkFlow_InstanceStepDto.Id))
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "步骤Id不能为空";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    if (eidtWorkFlow_InstanceStepDto.OutNum <= 0)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "申请数量错误";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    if (eidtWorkFlow_InstanceStepDto.ReviewStatus != WorkFlow_InstanceStepStatusEnums.同意 && eidtWorkFlow_InstanceStepDto.ReviewStatus != WorkFlow_InstanceStepStatusEnums.驳回)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "审核结果参数错误";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    // 根据Id获取到对应的步骤信息并重新赋值
                    WorkFlow_InstanceStep workFlow_InstanceStep = _workFlow_InstanceStepDal.GetAll().Find(eidtWorkFlow_InstanceStepDto.Id);
                    if (workFlow_InstanceStep == null)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "未找到对应工作流步骤";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    workFlow_InstanceStep.ReviewReason = eidtWorkFlow_InstanceStepDto.ReviewReason;
                    workFlow_InstanceStep.ReviewStatus = eidtWorkFlow_InstanceStepDto.ReviewStatus;
                    workFlow_InstanceStep.ReviewTime = DateTime.Now;
                    // 修改对应部门经理步骤
                    if (!_workFlow_InstanceStepDal.EditAsync(workFlow_InstanceStep).Result)
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "审核失败,请稍后再试";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }

                    
                    // 判断当前登录用户是什么角色
                    // 当前用户拥有的角色
                    List<string> roleNames = (from a in _iR_UserInfo_RoleInfoDal.GetAll().Where(r => r.UserId.Equals(workFlow_InstanceStep.ReviewerId))
                                              join b in _roleInfoDal.GetAll().Where(r => !r.IsDelete)
                                              on a.RoleId equals b.Id
                                              select b.RoleName).ToList();
                    // 判断审核是哪种操作
                    if (eidtWorkFlow_InstanceStepDto.ReviewStatus == WorkFlow_InstanceStepStatusEnums.同意)
                    {
                        if (roleNames.Contains("部门经理"))
                        {
                            // 获取到拥有仓库管理员角色的用户列表
                            List<string> WarehouseIds = (from a in _roleInfoDal.GetAll().Where(r => !r.IsDelete && r.RoleName.Equals("仓库管理员"))
                                                         join b in _iR_UserInfo_RoleInfoDal.GetAll()
                                                         on a.Id equals b.RoleId
                                                         select b.UserId).ToList();
                            if (WarehouseIds == null)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "未找到仓库管理员";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }

                            // 创建仓库管理员工作流步骤
                            WorkFlow_InstanceStep warehouseWorkFlow_InstanceStep = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                InstanceId = workFlow_InstanceStep.InstanceId,
                                ReviewerId = WarehouseIds[0], // 仓库管理员Id
                                BeforeStepId = workFlow_InstanceStep.Id,
                                ReviewStatus = WorkFlow_InstanceStepStatusEnums.审核中,
                                CreateTime = DateTime.Now
                            };
                            if (!_workFlow_InstanceStepDal.AddAsync(warehouseWorkFlow_InstanceStep).Result)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "添加仓库管理员工作流步骤失败";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }
                        }
                        else if (roleNames.Contains("仓库管理员"))
                        {
                            // 获取对应工作流实例信息
                            WorkFlow_Instance workFlow_Instance = _workFlow_InstanceDal.GetAll().FirstOrDefault(w => w.Id.Equals(workFlow_InstanceStep.InstanceId));
                            if (workFlow_Instance == null)
                            {
                                dbTransaction.Rollback();
                                msg = "查询不到对应工作流实例";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 获取到对应耗材信息
                            ConsumableInfo consumableInfo = _consumableInfoDal.GetAll()
                                .Where(c => !c.IsDelete)
                                .FirstOrDefault(c => c.Id.Equals(workFlow_Instance.OutGoodsId));

                            // 判断耗材信息是否为空
                            if (consumableInfo == null)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "查询不到对应的耗材信息";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 判断库存是否足够出库
                            if (workFlow_Instance.OutNum > consumableInfo.Num)
                            {
                                dbTransaction.Rollback();
                                msg = "库存不足";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 出库
                            consumableInfo.Num -= workFlow_Instance.OutNum;
                            if (!_consumableInfoDal.EditAsync(consumableInfo).Result)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "更新耗材库存失败";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 添加耗材记录
                            // 构建耗材记录对象并赋值
                            ConsumableRecord consumableRecord = new ConsumableRecord()
                            {
                                Id = Guid.NewGuid().ToString(),
                                ConsumableId = workFlow_Instance.OutGoodsId,
                                Num = workFlow_Instance.OutNum,
                                Type = ConsumableRecordTypeEnums.出库,
                                CreateTime = DateTime.Now,
                                Creator = workFlow_Instance.Creator
                            };
                            if (!_consumableRecordDal.AddAsync(consumableRecord).Result)
                            {
                                // 回滚
                                dbTransaction.Commit();
                                msg = "添加耗材记录失败";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 修改工作流实例状态
                            workFlow_Instance.Status = WorkFlow_InstanceStatusEnum.结束;
                            if (!_workFlow_InstanceDal.EditAsync(workFlow_Instance).Result)
                            {
                                dbTransaction.Rollback();
                                msg = "更新工作流实例失败";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }


                        }
                        else if (roleNames.Contains("普通员工"))
                        {
                            // 普通员工审核，给部门经理添加一条新的工作流步骤
                            // 查询上一个步骤信息
                            WorkFlow_InstanceStep wis = _workFlow_InstanceStepDal.GetAll().FirstOrDefault(w => w.Id.Equals(workFlow_InstanceStep.BeforeStepId));
                            if (wis == null)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "未获取上一个步骤的信息";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 创建工作流步骤对象并赋值
                            WorkFlow_InstanceStep workFlow_InstanceStep1 = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                InstanceId = workFlow_InstanceStep.InstanceId,
                                ReviewerId = wis.ReviewerId,
                                CreateTime = DateTime.Now,
                                BeforeStepId = workFlow_InstanceStep.Id,
                                ReviewStatus = WorkFlow_InstanceStepStatusEnums.审核中,
                            };
                            if (!_workFlow_InstanceStepDal.AddAsync(workFlow_InstanceStep1).Result)
                            {
                                dbTransaction.Rollback();
                                msg = "添加工作流步骤失败";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }
                            
                            // 获取对应工作流实例信息
                            WorkFlow_Instance workFlow_Instance = _workFlow_InstanceDal.GetAll().FirstOrDefault(w => w.Id.Equals(workFlow_InstanceStep.InstanceId));
                            if (workFlow_Instance == null)
                            {
                                dbTransaction.Rollback();
                                msg = "查询不到对应工作流实例";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }

                            // 修改实例表的申请耗材数量
                            workFlow_Instance.OutNum = eidtWorkFlow_InstanceStepDto.OutNum;
                            // 修改工作流实例表的申请耗材数量
                            if (!_workFlow_InstanceDal.EditAsync(workFlow_Instance).Result)
                            {
                                dbTransaction.Rollback();
                                msg = "修改申请耗材数量失败";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }
                        }
                        else
                        {
                            dbTransaction.Rollback();
                            msg = "审核工作流步骤失败";
                            return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                        }

                        
                    }
                    else if(eidtWorkFlow_InstanceStepDto.ReviewStatus == WorkFlow_InstanceStepStatusEnums.驳回)
                    {
                        if (roleNames.Contains("部门经理"))
                        {
                            // 获取对应工作流实例信息
                            WorkFlow_Instance workFlow_Instance = _workFlow_InstanceDal.GetAll().FirstOrDefault(w => w.Id.Equals(workFlow_InstanceStep.InstanceId));
                            if (workFlow_Instance == null)
                            {
                                dbTransaction.Rollback();
                                msg = "查询不到对应工作流实例";
                                return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                            }
                            // 部门经理驳回操作，给申请人一条工作流步骤数据
                            WorkFlow_InstanceStep creatorWorkFlow_InstanceStep = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                InstanceId = workFlow_InstanceStep.InstanceId,
                                ReviewerId = workFlow_Instance.Creator,
                                BeforeStepId = workFlow_InstanceStep.Id,
                                CreateTime = DateTime.Now,
                                ReviewStatus = WorkFlow_InstanceStepStatusEnums.审核中,
                            };
                            // 添加一条步骤信息
                            if (!_workFlow_InstanceStepDal.AddAsync(creatorWorkFlow_InstanceStep).Result)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "创建工作流步骤失败";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }
                        }
                        else if (roleNames.Contains("仓库管理员"))
                        {
                            // 找到上一个工作流步骤的数据
                            WorkFlow_InstanceStep wis2 = _workFlow_InstanceStepDal.GetAll().FirstOrDefault(w => w.Id.Equals(workFlow_InstanceStep.BeforeStepId));
                            if(wis2 == null)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "查询不到上个工作流步骤数据";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }
                            // 仓库管理员驳回操作，给部门经理一条工作流步骤数据
                            WorkFlow_InstanceStep creatorWorkFlow_InstanceStep = new WorkFlow_InstanceStep()
                            {
                                Id = Guid.NewGuid().ToString(),
                                InstanceId = workFlow_InstanceStep.InstanceId,
                                ReviewerId = wis2.ReviewerId,
                                BeforeStepId = workFlow_InstanceStep.Id,
                                CreateTime = DateTime.Now,
                                ReviewStatus = WorkFlow_InstanceStepStatusEnums.审核中,
                            };
                            // 添加一条步骤信息
                            if (!_workFlow_InstanceStepDal.AddAsync(creatorWorkFlow_InstanceStep).Result)
                            {
                                // 回滚
                                dbTransaction.Rollback();
                                msg = "创建工作流步骤失败";
                                return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                            }
                        }
                    }
                    else
                    {
                        // 回滚
                        dbTransaction.Rollback();
                        msg = "审核状态有误";
                        return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepError;
                    }
                    // 提交事务
                    dbTransaction.Commit();
                    msg = "审核成功";
                    return WorkFlow_InstanceStepEnums.EditWorkFlow_InstanceStepSuccess;
                }
                catch (Exception)
                {
                    // 回滚
                    dbTransaction.Rollback();
                    msg = "系统发生错误";
                    return WorkFlow_InstanceStepEnums.AddWorkFlow_InstanceStepError;
                }
            }
            

        }
    }
}
