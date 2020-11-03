//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//******************************* 
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace FreeSqlBuilderPlanX.Application.Dto.Role
{
    public class RoleAutoMapperProfile:Profile
    {
        public RoleAutoMapperProfile(){

        CreateMap<FreeSqlBuilderPalanX.Application.Entity.Role,RoleDto>();

        CreateMap<RoleRequestDto,FreeSqlBuilderPalanX.Application.Entity.Role>();

        }
    }
}