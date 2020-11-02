using AutoMapper;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    public class ApplicationMenuAutoMapperProfile : Profile
    {
        public ApplicationMenuAutoMapperProfile()
        {
            CreateMap<ApplicationMenuDto, FreeSqlBuilderPalanX.Application.Entity.ApplicationMenu>();
            CreateMap<FreeSqlBuilderPalanX.Application.Entity.ApplicationMenu,ApplicationMenuDto>();
        }
    }
}