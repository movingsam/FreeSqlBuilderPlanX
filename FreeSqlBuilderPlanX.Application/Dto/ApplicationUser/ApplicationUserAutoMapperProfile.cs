//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//******************************* 
using AutoMapper;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationUser;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    public class ApplicationUserAutoMapperProfile:Profile
    {
        public ApplicationUserAutoMapperProfile(){

        CreateMap<Entity.ApplicationUser,ApplicationUserDto>();

        CreateMap<ApplicationUserRequestDto,Entity.ApplicationUser>();

        }
    }
}