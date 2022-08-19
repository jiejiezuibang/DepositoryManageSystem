using System;
using System.Collections.Generic;
using System.Text;

namespace Sister.Dtos.MenuInfo
{
    public class HomeMenuDto
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图标样式
        /// </summary>

        public string Icon { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 访问地址
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// logo
        /// </summary>
        public string Image { get; set; }
        public List<HomeMenuDto> Child { get; set; }
    }
}
