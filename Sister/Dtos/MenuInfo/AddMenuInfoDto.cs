using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.MenuInfo
{
    public class AddMenuInfoDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 等级
        /// </summary>

        public int Level { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 访问地址
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 父菜单Id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 图标样式
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }
    }
}
