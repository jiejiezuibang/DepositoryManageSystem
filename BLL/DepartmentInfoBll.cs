using Common.ResultEnums;
using DAL;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.EntityFrameworkCore;
using Sister;
using Sister.Dtos.DeparmentInfo;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentInfoBll: IDepartmentInfoBll
    {
        // 注入部门管理dal
        private readonly IDepartmentInfoDal _departmentInfoDal;
        // 注入用户管理dal
        private readonly IUserInfoDal _userInfoDal;
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal,IUserInfoDal userInfoDal)
        {
            this._departmentInfoDal = departmentInfoDal;
            this._userInfoDal = userInfoDal;
        }
        /// <summary>
        /// 获取全部部门表信息
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> GetDepartmentInfoBll()
        {
            return _departmentInfoDal.GetAll().ToList();
        }
        /// <summary>
        /// 根据Id查询对应的部门信息
        /// </summary>
        /// <param name="Id">部门信息</param>
        /// <returns></returns>
        public async Task<DepartmentInfo> FindDepartmentInfoBll(string Id)
        {
            return await _departmentInfoDal.GetAll().FindAsync(Id);
        }
        /// <summary>
        /// 获取部门信息并有分页和查询搜索
        /// </summary>
        /// <param name="findDeparmentInfoDto">查询与分页条件</param>
        /// <param name="DeparmentCount">部门信息总条数</param>
        /// <returns></returns>
        public List<DeparmentInfoDto> GetDeparmentInfoDtosShowBll(FindDeparmentInfoDto findDeparmentInfoDto, out int DeparmentCount)
        {
            // 获取部门数据集
            DbSet<DepartmentInfo> departmentInfos = _departmentInfoDal.GetAll();
            // 获取用户数据集
            DbSet<UserInfo> userInfos = _userInfoDal.GetAll();
            var deparmentInfoDtos = from a in departmentInfos
           .Where(d => !d.IsDelete)    // 过滤已删除的部门
           .OrderByDescending(d => d.CreateTime)   // 降序排序
           join b in userInfos
           on a.LeaderId equals b.Id
           into JoinAB
           from tempAB in JoinAB.DefaultIfEmpty() 
           join c in departmentInfos.Where(d => !d.IsDelete)
           on a.ParentId equals c.Id
           into JoinAC 
           from tempAc in JoinAC.DefaultIfEmpty()
                                    select new DeparmentInfoDto
                                    {
                                        Id = a.Id,
                                        Description = a.Description,
                                        DepartmentName = a.DepartmentName,
                                        LeaderName = tempAB.UserName,
                                        ParentName = tempAc.DepartmentName,
                                        CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                                    };
            DeparmentCount = deparmentInfoDtos.Count();
            // 查询搜索
            if (findDeparmentInfoDto.DepartmentName != null)
            {
                deparmentInfoDtos = deparmentInfoDtos.Where(d => d.DepartmentName.Contains(findDeparmentInfoDto.DepartmentName));
            }
            // 分页
            return deparmentInfoDtos.Skip(findDeparmentInfoDto.limit * (findDeparmentInfoDto.page - 1))
                .Take(findDeparmentInfoDto.limit).ToList();
        }
        /// <summary>
        /// 校验前端传递过来的添加部门信息数据
        /// </summary>
        /// <param name="addDeparmentInfoDto">添加部门信息dto</param>
        /// <returns></returns>
        public AjaxResult AddDeparmentDataCheck(AddDeparmentInfoDto addDeparmentInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult(); 
            if (string.IsNullOrEmpty(addDeparmentInfoDto.DepartmentName))
            {
                ajaxResult.code = 501;
                ajaxResult.msg = "部门名称不能为空";
            }
            ajaxResult.code = 200;
            return ajaxResult;
        }
        /// <summary>
        /// 添加部门信息业务
        /// </summary>
        public async Task<DeparmentEnums> AddDeparmentInfoBll(AddDeparmentInfoDto addDeparmentInfoDto)
        {
            // 判断部门是否存在
            if (await _departmentInfoDal.GetAll().FirstOrDefaultAsync(d => d.DepartmentName == addDeparmentInfoDto.DepartmentName) != null)
            {
                return DeparmentEnums.AddDeparmentNameExist;
            }
            // 创建部门对象并赋值
            DepartmentInfo departmentInfo = new DepartmentInfo
            {
                Id = Guid.NewGuid().ToString(),
                DepartmentName = addDeparmentInfoDto.DepartmentName,
                Description = addDeparmentInfoDto.Description,
                LeaderId = addDeparmentInfoDto.LeaderId,
                ParentId = addDeparmentInfoDto.ParentId,
                CreateTime = DateTime.Now,
            };
            // 判断是否添加成功
            if (await _departmentInfoDal.AddAsync(departmentInfo))
            {
                return DeparmentEnums.AddDeparmentSuccess;
            }
            return DeparmentEnums.AddDeparmentError;
        }
        /// <summary>
        /// 校验前端传递过来的修改部门信息数据
        /// </summary>
        /// <param name="editDeparmentInfoDto">修改部门dto</param>
        /// <returns></returns>
        public AjaxResult EditDeparmentDataCheck(EditDeparmentInfoDto editDeparmentInfoDto)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if (string.IsNullOrEmpty(editDeparmentInfoDto.DepartmentName))
            {
                ajaxResult.code = 501;
                ajaxResult.msg = "部门名称不能为空";
            }
            ajaxResult.code = 200;
            return ajaxResult;
        }
        /// <summary>
        /// 修改部门信息业务
        /// </summary>
        /// <param name="editDeparmentInfoDto">修改部门dto</param>
        /// <returns></returns>
        public async Task<DeparmentEnums> EditDeparmentInfoBll(EditDeparmentInfoDto editDeparmentInfoDto)
        {
            // 查询要修改的部门
            DepartmentInfo departmentInfo = await _departmentInfoDal.GetAll().FindAsync(editDeparmentInfoDto.Id);
            // 赋值要修改的新值
            departmentInfo.DepartmentName = editDeparmentInfoDto.DepartmentName;
            departmentInfo.Description = editDeparmentInfoDto.Description;
            departmentInfo.LeaderId = editDeparmentInfoDto.LeaderId;
            departmentInfo.ParentId = editDeparmentInfoDto.ParentId;
            // 判断是否修改成功
            if (await _departmentInfoDal.EditAsync(departmentInfo))
            {
                return DeparmentEnums.EditDeparmentSuccess;
            }
            return DeparmentEnums.EditDeparmentError;

        }
        /// <summary>
        /// 删除部门信息业务
        /// </summary>
        /// <param name="IdList">要删除的部门id</param>
        /// <returns></returns>
        public async Task<DeparmentEnums> DelDeparmentInfoBll(string[] IdList)
        {
            // 判断是否删除成功
            if(await _departmentInfoDal.DelAsync(IdList))
            {
                return DeparmentEnums.DelDeparmentSuccess;
            }
            return DeparmentEnums.DelDeparmentError;
        }
        /// <summary>
        /// 获取部门信息作为下拉框数据
        /// </summary>
        /// <returns></returns>
        public List<SelectOptionsDto> GetSelectOptions()
        {
            return _departmentInfoDal.GetAll().Select(d => new SelectOptionsDto { Title = d.DepartmentName, Value = d.Id }).ToList();
        }
    }
}
