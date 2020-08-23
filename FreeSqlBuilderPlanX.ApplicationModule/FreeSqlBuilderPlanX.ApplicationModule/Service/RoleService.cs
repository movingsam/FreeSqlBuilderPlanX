//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSql;
using System;
using System.Collections.Generic;

using FreeSqlBuilderPlanX.ApplicationModule.Dto;
using FreeSqlBuilderPlanX.ApplicationModule.PageRequest;
using FreeSqlBuilderPlanX.ApplicationModule.PageViewDto;
using FreeSqlBuilderPlanX.ApplicationModule.RequestDto;

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.ApplicationModule.Service
{

        ///<summary>
        /// 服务
        ///</summary>
public class RoleService {
        private readonly IFreeSql _freeSql;
        private readonly ILogger<RoleService> _logger;
        private readonly IMapper _mapper;

        ///<summary>
        /// 构造函数
        ///</summary>
    public RoleService(IServiceProvider service,ILogger<RoleService>
    logger) {
    this._freeSql = service.GetService<IFreeSql>();
    _logger = logger;
    _mapper = service.GetService<IMapper>();
    }


        ///<summary>
        /// 新增
        ///</summary>
public async Task<bool> NewRoleService (RoleDto dto){

     using var uow = _freeSql.CreateUnitOfWork();
     var rep = _freeSql.GetRepository<Role>();
     rep.UnitOfWork = uow;
     var entity = _mapper.Map<Role>(dto);
     var insert = await rep.InsertAsync(entity);
     uow.Commit();
     return true;

}

        ///<summary>
        /// 修改
        ///</summary>
public async Task<bool> UpdateRole (RoleDto dto){
   using var uow = _freeSql.CreateUnitOfWork();
        var rep = _freeSql.GetRepository<Role>();
        rep.UnitOfWork = uow;
        var entity = _mapper.Map<Role>(dto);
        rep.Update(entity);
        uow.Commit();
        return true;

}
        ///<summary>
        /// 删除
        ///</summary>
public async Task<bool> DeleteRole(List<Guid> ids){

      using var uow = _freeSql.CreateUnitOfWork();
      var rep = _freeSql.GetRepository<Role>();
      rep.UnitOfWork = uow;
      await rep.DeleteAsync(x=>ids.Contains(x.Id));
      uow.Commit();
      return true;

}
        ///<summary>
        /// 分页查询
        ///</summary>
public async Task<RolePageViewDto> QueryRolePage (RolePageRequest request){

    var rep = _freeSql.GetRepository<Role>();
    var datas =await rep.Select.IncludeMany(rol=>rol.Users)

                 .WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy),x=>x.CreateBy.Contains(request.CreateBy))
.WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy),x=>x.UpdateBy.Contains(request.UpdateBy))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(!string.IsNullOrWhiteSpace(request.Name),x=>x.Name.Contains(request.Name))
.WhereIf(!string.IsNullOrWhiteSpace(request.Code),x=>x.Code.Contains(request.Code))
.WhereIf(!string.IsNullOrWhiteSpace(request.Descriptions),x=>x.Descriptions.Contains(request.Descriptions))

                 .Count(out var total)
                 .Page(request.PageNumber, request.PageSize)
                 .ToListAsync<RoleDto>();
    var page = new RolePageViewDto(datas,total, request.PageNumber, request.PageSize);
    return page;

}

public async Task<RoleDto> QueryRole (RoleRequestDto request){

    var rep = _freeSql.GetRepository<Role>();
    var res = await rep.Select.IncludeMany(rol=>rol.Users)
.WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy),x=>x.CreateBy.Contains(request.CreateBy))
.WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy),x=>x.UpdateBy.Contains(request.UpdateBy))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(!string.IsNullOrWhiteSpace(request.Name),x=>x.Name.Contains(request.Name))
.WhereIf(!string.IsNullOrWhiteSpace(request.Code),x=>x.Code.Contains(request.Code))
.WhereIf(!string.IsNullOrWhiteSpace(request.Descriptions),x=>x.Descriptions.Contains(request.Descriptions))
.ToOneAsync<RoleDto>();
    return res;

}    }
}