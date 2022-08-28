using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Sister;
using Sister.Dtos.UserInfo;
using Sister.Dtos.WorkFlow_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 工作流模板业务对象
    /// </summary>
    public class WorkFlow_ModelBll: IWorkFlow_ModelBll
    {
        // 构建工作流模板dal对象
        private readonly IWorkFlow_ModelDal _workFlow_ModelDal;
        public WorkFlow_ModelBll(IWorkFlow_ModelDal workFlow_ModelDal)
        {
            this._workFlow_ModelDal = workFlow_ModelDal;
        }
        /// <summary>
        /// 添加工作流模板业务
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        public async Task<WorkFlow_ModelEnums> AddWorkFlow_ModelBll(string Title, string Description)
        {
            // 创建工作流模板对象并赋值
            WorkFlow_Model workFlow_Model = new WorkFlow_Model()
            {
                Id = Guid.NewGuid().ToString(),
                Title = Title,
                IsDelete = false,
                CreateTime = DateTime.Now,
                Description = Description
            };
            if(await _workFlow_ModelDal.AddAsync(workFlow_Model))
            {
                return WorkFlow_ModelEnums.AddWorkFlow_ModelSuccess;
            }
            return WorkFlow_ModelEnums.AddWorkFlow_ModelError;
        }
        /// <summary>
        /// 删除工作流模板信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public async Task<WorkFlow_ModelEnums> DelWorkFlow_ModelBll(string[] IdList)
        {
            if (await _workFlow_ModelDal.DelAsync(IdList))
            {
                return WorkFlow_ModelEnums.DelWorkFlow_ModelSuccess;
            }
            else
            {
                return WorkFlow_ModelEnums.DelWorkFlow_ModelError;
            }
        }
        /// <summary>
        /// 修改工作流模板信息
        /// </summary>
        /// <param name="Id">编号</param>
        /// <param name="Title">标题</param>
        /// <param name="Description">描述</param>
        /// <returns></returns>
        public async Task<WorkFlow_ModelEnums> EditWorkFlow_ModelBll(string Id,string Title,string Description)
        {
            WorkFlow_Model workFlow_Model = await _workFlow_ModelDal.GetAll().FindAsync(Id);
            if(workFlow_Model != null)
            {
                workFlow_Model.Title = Title;
                workFlow_Model.Description = Description;
                if(await _workFlow_ModelDal.EditAsync(workFlow_Model))
                {
                    return WorkFlow_ModelEnums.EditWorkFlow_ModelSuccess;
                }
            }
            return WorkFlow_ModelEnums.EditWorkFlow_ModelError;
        }
        /// <summary>
        /// 获取工作流模板全部数据业务
        /// </summary>
        /// <param name="findWorkFlow_ModelDto"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<WorkFlow_ModelDto> GetShowWorkFlow_ModelBll(FindWorkFlow_ModelDto findWorkFlow_ModelDto,out int Count)
        {
            var workFlow_Models =(from a in _workFlow_ModelDal.GetAll()
                .Where(w => !w.IsDelete)
                 .OrderByDescending(w => w.CreateTime)
            select new WorkFlow_ModelDto
            {
                Id = a.Id,
                Title = a.Title,
                CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
                Description = a.Description,
            });
            if (findWorkFlow_ModelDto.Title != null)
            {
                workFlow_Models = workFlow_Models.Where(w => w.Title.Contains(findWorkFlow_ModelDto.Title));
            }
            Count = workFlow_Models.Count();
            return workFlow_Models.Skip(findWorkFlow_ModelDto.limit * (findWorkFlow_ModelDto.page - 1)).Take(findWorkFlow_ModelDto.limit).ToList();
        }
        /// <summary>
        /// 通过Id查询对应工作流模板信息
        /// </summary>
        /// <returns></returns>
        public async Task<WorkFlow_Model> FindWorkFlow_ModelBll(string Id)
        {
            return await _workFlow_ModelDal.GetAll().FindAsync(Id);
        }
        /// <summary>
        /// 获取工作流实例信息作为下拉框的数据
        /// </summary>
        public List<SelectOptionsDto> GetSelectOptions()
        {
            return _workFlow_ModelDal.GetAll()
                .Where(w => !w.IsDelete)
                .Select(w => new SelectOptionsDto { Title = w.Title, Value = w.Id }).ToList();
        }
    }
}
