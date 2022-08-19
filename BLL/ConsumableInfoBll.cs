using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Sister;
using Sister.Dtos.ConsumabelInfo;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConsumableInfoBll: IConsumableInfoBll
    {
        /// <summary>
        /// 注入耗材信息dal对象
        /// </summary>
        private readonly IConsumableInfoDal _consumableInfoDal;
        /// <summary>
        /// 注入耗材类别dal对象
        /// </summary>
        private readonly ICategoryDal _categoryDal;
        public ConsumableInfoBll(IConsumableInfoDal consumableInfoDal, ICategoryDal categoryDal)
        {
            this._consumableInfoDal = consumableInfoDal;
            this._categoryDal = categoryDal;
        }
        public async Task<ConsumableInfoEnums> AddConsumabelInfoBll(AddConsumabelInfoDto addConsumabelInfoDto)
        {
            // 创建耗材信息对象并赋值
            ConsumableInfo consumableInfo = new ConsumableInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Description = addConsumabelInfoDto.Description,
                CategoryId = addConsumabelInfoDto.CategoryId,
                ConsumableName = addConsumabelInfoDto.ConsumableName,
                Specification = addConsumabelInfoDto.Specification,
                Num = addConsumabelInfoDto.Num,
                Unit = addConsumabelInfoDto.Unit,
                Money = addConsumabelInfoDto.Money,
                WarningNum = addConsumabelInfoDto.WarningNum,
                IsDelete = false,
                CreateTime = DateTime.Now,
            };
            if(await _consumableInfoDal.AddAsync(consumableInfo))
            {
                return ConsumableInfoEnums.AddConumableInfoSuccess;
            }
            return ConsumableInfoEnums.AddConumableInfoError;
        }
        /// <summary>
        /// 删除耗材信息
        /// </summary>
        /// <param name="IdList">耗材信息Id</param>
        /// <returns></returns>
        public async Task<ConsumableInfoEnums> DelConsumabelInfoBll(string[] IdList)
        {
            if (IdList != null)
            {
                if(await _consumableInfoDal.DelAsync(IdList))
                {
                    return ConsumableInfoEnums.DelConumableInfoSuccess;
                }
            }
            return ConsumableInfoEnums.DelConumableInfoError;
        }
        /// <summary>
        /// 修改耗材信息业务
        /// </summary>
        /// <param name="editConsumabelInfoDto">修改耗材信息dto</param>
        /// <returns></returns>
        public async Task<ConsumableInfoEnums> EditConsumabelInfoBll(EditConsumabelInfoDto editConsumabelInfoDto)
        {
            ConsumableInfo consumableInfo = await _consumableInfoDal.GetAll().FindAsync(editConsumabelInfoDto.Id);
            if (consumableInfo != null)
            {
                consumableInfo.Description = editConsumabelInfoDto.Description;
                consumableInfo.CategoryId = editConsumabelInfoDto.CategoryId;
                consumableInfo.ConsumableName = editConsumabelInfoDto.ConsumableName;
                consumableInfo.Specification = editConsumabelInfoDto.Specification;
                consumableInfo.Num = editConsumabelInfoDto.Num;
                consumableInfo.Unit = editConsumabelInfoDto.Unit;
                consumableInfo.Money = editConsumabelInfoDto.Money;
                consumableInfo.WarningNum = editConsumabelInfoDto.WarningNum;
                if(await _consumableInfoDal.EditAsync(consumableInfo))
                {
                    return ConsumableInfoEnums.EditCoumableInfoSuccess;
                }
            }
            return ConsumableInfoEnums.EditCoumableInfoError;
        }
        /// <summary>
        /// 获取要展示的耗材信息数据业务
        /// </summary>
        /// <param name="findConsumabelInfoDto">查询分页dto</param>
        /// <returns></returns>
        public List<ConsumabelInfoDto> GetConsumabelInfoShow(FindConsumabelInfoDto findConsumabelInfoDto)
        {
            IQueryable<ConsumabelInfoDto> consumabelInfoDtos = from a in _consumableInfoDal.GetAll()
                .Where(m => !m.IsDelete)
                .OrderByDescending(m => m.CreateTime)
                                                               join b in _categoryDal.GetAll()
                                                               on a.CategoryId equals b.Id
                                                               into abJoin
                                                               from c in abJoin.DefaultIfEmpty()
                                                               select new ConsumabelInfoDto
                                                               {
                                                                   Id = a.Id,
                                                                   Description = a.Description,
                                                                   CategoryName = c.CategoryName,
                                                                   ConsumableName = a.ConsumableName,
                                                                   Specification = a.Specification,
                                                                   Num = a.Num,
                                                                   Unit = a.Unit,
                                                                   Money = a.Money,
                                                                   WarningNum = a.WarningNum,
                                                                   CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                                                               };
            if(findConsumabelInfoDto.ConsumableName != null)
            {
                consumabelInfoDtos = consumabelInfoDtos.Where(m => m.ConsumableName.Contains(findConsumabelInfoDto.ConsumableName));
            }
            return consumabelInfoDtos.Skip(findConsumabelInfoDto.limit * (findConsumabelInfoDto.page - 1)).Take(findConsumabelInfoDto.limit).ToList();
        }
        /// <summary>
        /// 通过Id查询对应的耗材信息
        /// </summary>
        public async Task<ConsumableInfo> FindConsumabelInfoBll(string Id)
        {
            return await _consumableInfoDal.GetAll().FindAsync(Id);
        }
    }
}
