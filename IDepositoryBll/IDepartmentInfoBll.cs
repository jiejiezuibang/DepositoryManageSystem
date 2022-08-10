using Common.ResultEnums;
using Sister;
using Sister.Dtos.DeparmentInfo;
using Sister.Dtos.UserInfo;
using Sister.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDepositoryBll
{
    /// <summary>
    /// 部门管理bll层接口
    /// </summary>
    public interface IDepartmentInfoBll
    {
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <returns></returns>
        List<DepartmentInfo> GetDepartmentInfoBll();
        /// <summary>
        /// 根据部门Id查询对应的部门信息
        /// </summary>
        /// <param name="Id">部门Id</param>
        /// <returns></returns>
        Task<DepartmentInfo> FindDepartmentInfoBll(string Id);
        /// <summary>
        /// 获取展示的部门信息并且有分页与查询搜索
        /// </summary>
        /// <returns></returns>
        List<DeparmentInfoDto> GetDeparmentInfoDtosShowBll(FindDeparmentInfoDto findDeparmentInfoDto,out int DeparmentCount);
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="addDeparmentInfoDto"></param>
        /// <returns></returns>
        Task<DeparmentEnums> AddDeparmentInfoBll(AddDeparmentInfoDto addDeparmentInfoDto);
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<DeparmentEnums> EditDeparmentInfoBll(EditDeparmentInfoDto editDeparmentInfoDto);
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        Task<DeparmentEnums> DelDeparmentInfoBll(string[] IdList);
        /// <summary>
        /// 校验添加部门信息
        /// </summary>
        /// <param name="addDeparmentInfoDto">添加部门信息dto</param>
        /// <returns></returns>
        AjaxResult AddDeparmentDataCheck(AddDeparmentInfoDto addDeparmentInfoDto);
        /// <summary>
        /// 校验修改部门信息
        /// </summary>
        /// <param name="editDeparmentInfoDto">修改部门信息dto</param>
        AjaxResult EditDeparmentDataCheck(EditDeparmentInfoDto editDeparmentInfoDto);
        /// <summary>
        /// 获取部门信息作为下拉框的数据
        /// </summary>
        /// <returns></returns>
        List<SelectOptionsDto> GetSelectOptions();
    }
}
