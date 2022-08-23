using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultEnums
{
    public enum ConsumableInfoEnums
    {
        /// <summary>
        /// 添加耗材信息成功
        /// </summary>
        AddConumableInfoSuccess,
        /// <summary>
        /// 添加耗材信息失败
        /// </summary>
        AddConumableInfoError,
        /// <summary>
        /// 删除耗材信息成功
        /// </summary>
        DelConumableInfoSuccess,
        /// <summary>
        /// 删除耗材信息失败
        /// </summary>
        DelConumableInfoError,
        /// <summary>
        /// 修改耗材信息成功
        /// </summary>
        EditCoumableInfoSuccess,
        /// <summary>
        /// 修改耗材信息失败
        /// </summary>
        EditCoumableInfoError,
        /// <summary>
        /// 入库成功
        /// </summary>
        WarehousingSuccess,
        /// <summary>
        /// 入库失败
        /// </summary>
        WarehousingError,
        /// <summary>
        /// 文件类型错误
        /// </summary>
        FileTypeError,
        /// <summary>
        /// 文件数据不对
        /// </summary>
        FileDataError,
    }
}
