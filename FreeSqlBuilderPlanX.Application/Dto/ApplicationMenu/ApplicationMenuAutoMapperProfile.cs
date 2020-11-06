//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//******************************* 
using AutoMapper;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationMenu;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    public class ApplicationMenuAutoMapperProfile:Profile
    {
        public ApplicationMenuAutoMapperProfile(){

        CreateMap<Entity.ApplicationMenu,ApplicationMenuDto>();

        CreateMap<ApplicationMenuRequestDto,Entity.ApplicationMenu>();

        }
    }
}