//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//******************************* 
using AutoMapper;
using FreeSqlBuilderPlanX.Web.Dto.Role;

namespace FreeSqlBuilderPlanX.Application.Dto.Role
{
    public class RoleAutoMapperProfile : Profile
    {
        public RoleAutoMapperProfile()
        {

            CreateMap<Entity.Role, RoleDto>();

            CreateMap<RoleRequestDto, Entity.Role>();

        }
    }
}