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
        /// <summary>
        /// 注入用户管理dal对象
        /// </summary>
        private readonly IUserInfoDal _userInfoDal;
        /// <summary>
        /// 注入数据库上下文对象
        /// </summary>
        private readonly DepositoryContext _depositoryContext;
        public ConsumableInfoBll(IUserInfoDal userInfoDal , DepositoryContext depositoryContext,IConsumableInfoDal consumableInfoDal, ICategoryDal categoryDal, IConsumableRecordDal consumableRecordDal)
        {
            this._consumableInfoDal = consumableInfoDal;
            this._categoryDal = categoryDal;
            this._consumableRecordDal = consumableRecordDal;
            this._depositoryContext = depositoryContext;
            this._userInfoDal = userInfoDal;
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
        public ConsumableInfoEnums WarehousingBll(IFormFile formFile,string UserId,out string msg)
        {
            IWorkbook wk = null;
            // 获取文件的后缀名
            string extension = Path.GetExtension(formFile.FileName);
            if (extension == ".xls" || extension == ".xlsx")
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
                // 获取到表第一行数据
                IRow row = sheet.GetRow(0);
                // 校验文件数据是否正确
                if (row.GetCell(0).ToString() != "物品名称" || row.GetCell(1).ToString() != "数量" || row.GetCell(2).ToString() != "实际购买数量" || row.GetCell(3).ToString() != "规格")
                {
                    msg = "文件数据格式错误!";
                    return ConsumableInfoEnums.FileDataError;
                }
                using (var dbTransaction = _depositoryContext.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 1; i <= sheet.LastRowNum; i++)
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
                                if (!_consumableRecordDal.AddAsync(consumableRecord).Result)
                                {
                                    msg = $"导入{i}行数据发生错误";
                                    // 回滚
                                    dbTransaction.Rollback();
                                    return ConsumableInfoEnums.WarehousingError;
                                }

                                // 修改耗材信息数量业务
                                // 通过耗材信息Id获取到耗材信息
                                ConsumableInfo consumableInfo = _consumableInfoDal.GetAll().FindAsync(consumable.Id).Result;
                                // 修改耗材数量
                                consumableInfo.Num = consumableInfo.Num + Convert.ToInt32(cell_3);
                                if(!_consumableInfoDal.EditAsync(consumableInfo).Result)
                                {
                                    msg = $"修改{i}行耗材数据发生错误";
                                    // 回滚
                                    dbTransaction.Rollback();
                                    return ConsumableInfoEnums.WarehousingError;
                                }

                                
                            }
                            else
                            {
                                msg = $"第{i}行耗材信息发生错误，导入失败";
                                // 回滚
                                dbTransaction.Rollback();
                                return ConsumableInfoEnums.WarehousingError;
                            }
                        }
                        // 提交事务
                        dbTransaction.Commit();
                    }
                    catch(Exception)
                    {
                        msg = "导入数据发生未知错误";
                        // 回滚
                        dbTransaction.Rollback();
                        return ConsumableInfoEnums.WarehousingError;
                    }
                }

                msg = "导入数据成功";
                return ConsumableInfoEnums.WarehousingSuccess;
            }
            else
            {
                msg = "文件类型错误";
                return ConsumableInfoEnums.FileTypeError;
            }
        }
        /// <summary>
        /// 耗材出库业务
        /// </summary>
        public FileStream OutOfStockBll()
        {
            // 获取要导出的数据
            var data = (from a in _consumableRecordDal.GetAll()
            join b in _consumableInfoDal.GetAll()
            on a.ConsumableId equals b.Id
            into abJoin
            from bData in abJoin.DefaultIfEmpty()

            join c in _userInfoDal.GetAll()
            on a.Creator equals c.Id
            into acJoin
            from cData in acJoin.DefaultIfEmpty()
            select new
            {
                cData.UserName,
                bData.ConsumableName,
                a.Num,
                bData.Money,
                bData.Specification
            }).ToList();

            // 获取文件路径
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ling.xlsx");
            IWorkbook workbook = null;
            if (Path.GetExtension(filePath).Equals(".xlsx"))
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                workbook = new HSSFWorkbook();
            }
            ISheet sheet = workbook.CreateSheet("sheet1");
            // 创建第一行并初始化表头
            IRow row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue("创建人");
            row0.CreateCell(1).SetCellValue("名称");
            row0.CreateCell(2).SetCellValue("数量");
            row0.CreateCell(3).SetCellValue("单价");
            row0.CreateCell(4).SetCellValue("规格");
            for (int i = 0; i < data.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                // 创建人
                row.CreateCell(0).SetCellValue(data[i].UserName);
                // 耗材名称
                row.CreateCell(1).SetCellValue(data[i].ConsumableName);
                // 耗材数量
                row.CreateCell(2).SetCellValue(data[i].Num);
                // 耗材单价
                row.CreateCell(3).SetCellValue(data[i].Money);
                // 耗材规格
                row.CreateCell(4).SetCellValue(data[i].Specification);
            }
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fileStream);
            fileStream.Close();

            // 获取指定文件的文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            return fs;
        }
    }
}
