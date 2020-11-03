//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//******************************* 
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    public class ApplicationUserAutoMapperProfile:Profile
    {
        public ApplicationUserAutoMapperProfile(){

        CreateMap<FreeSqlBuilderPalanX.Application.Entity.ApplicationUser,ApplicationUserDto>();

        CreateMap<ApplicationUserRequestDto,FreeSqlBuilderPalanX.Application.Entity.ApplicationUser>();

        }
    }
}