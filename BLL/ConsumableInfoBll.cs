using Common.ResultEnums;
using IDepositoryBll;
using IDepositoryDal;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sister;
using Sister.Dtos.ConsumabelInfo;
using Sister.Dtos.UserInfo;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// 注入耗材记录dal对象
        /// </summary>
        private readonly IConsumableRecordDal _consumableRecordDal;
        public ConsumableInfoBll(IConsumableInfoDal consumableInfoDal, ICategoryDal categoryDal, IConsumableRecordDal consumableRecordDal)
        {
            this._consumableInfoDal = consumableInfoDal;
            this._categoryDal = categoryDal;
            this._consumableRecordDal = consumableRecordDal;
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
        /// <summary>
        /// 耗材入库业务
        /// </summary>
        /// <param name="formFile"></param>
        public async Task<ConsumableInfoEnums> WarehousingBll(IFormFile formFile,string UserId)
        {
            IWorkbook wk = null;
            // 获取文件的后缀名
            string extension = Path.GetExtension(formFile.FileName);
            if(extension == ".xls"|| extension == ".xlsx")
            {
                using (Stream stream = formFile.OpenReadStream())
                {
                    // 判断文件后缀名
                    if (extension.Equals(".xls"))
                    {
                        wk = new HSSFWorkbook(stream);
                    }
                    else
                    {
                        wk = new XSSFWorkbook(stream);
                    }
                }
                // 获取第一张表数据
                ISheet sheet = wk.GetSheetAt(0);
                for(int i = 1; i <= sheet.LastRowNum; i++)
                {
                    // 获取对应行的前三个格子文本
                    string cell_1 = sheet.GetRow(i).GetCell(0).ToString(); // 名称
                    string cell_3 = sheet.GetRow(i).GetCell(2).ToString(); // 实际购买数量
                    string cell_4 = sheet.GetRow(i).GetCell(3).ToString(); // 规格

                    int num = 0;
                    int.TryParse(cell_3, out num);
                    // 获取对应耗材Id
                    var consumable = _consumableInfoDal.GetAll().FirstOrDefault(c => c.ConsumableName.Equals(cell_1));
                    if (consumable != null)
                    {
                        // 创建耗材记录对象并赋值
                        ConsumableRecord consumableRecord = new ConsumableRecord()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ConsumableId = consumable.Id,
                            CreateTime = DateTime.Now,
                            Num = Convert.ToInt32(cell_3),
                            Creator = UserId,
                        };
                        // 执行添加操作
                        await _consumableRecordDal.AddAsync(consumableRecord);
                    }
                }
                return ConsumableInfoEnums.WarehousingSuccess;
            }
            else
            {
                return ConsumableInfoEnums.FileTypeErro;
            }
        }
    }
}
