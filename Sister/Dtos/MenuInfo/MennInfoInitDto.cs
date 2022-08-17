using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sister.Dtos.MenuInfo
{
    /// <summary>
    /// 渲染主页侧边栏选项dto
    /// </summary>
    public class MennInfoInitDto
    {
        public MennInfoInitDto(List<HomeMenuDto> homeMenuDto)
        {
            this.MenuInfo.FirstOrDefault().Child = homeMenuDto;
        }
        public HomeMenuDto HomeInfo { get; set; } = new HomeMenuDto
        {
            Title = "首页",
            Href = "/Home/FrontView",
        };
        public HomeMenuDto LogoInfo { get; set; } = new HomeMenuDto
        {
            Title = "LAYUI MINI",
            Image = "/layuimini/images/logo.png",
            Href = ""
        };
        public List<HomeMenuDto> MenuInfo { get; set; } = new List<HomeMenuDto>
        {
            new HomeMenuDto
            {
                Title = "常规管理",
                Icon = "fa fa-address-book",
                Href = "",
                Target = "_self"
            }
        };
    }
}
