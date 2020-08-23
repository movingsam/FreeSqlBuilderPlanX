//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSql;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
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
public class ApplicationUserService {
        private readonly IFreeSql _freeSql;
        private readonly ILogger<ApplicationUserService> _logger;
        private readonly IMapper _mapper;

        ///<summary>
        /// 构造函数
        ///</summary>
    public ApplicationUserService(IServiceProvider service,ILogger<ApplicationUserService>
    logger) {
    this._freeSql = service.GetService<IFreeSql>();
    _logger = logger;
    _mapper = service.GetService<IMapper>();
    }


        ///<summary>
        /// 新增
        ///</summary>
public async Task<bool> NewApplicationUserService (ApplicationUserDto dto){

     using var uow = _freeSql.CreateUnitOfWork();
     var rep = _freeSql.GetRepository<ApplicationUser>();
     rep.UnitOfWork = uow;
     var entity = _mapper.Map<ApplicationUser>(dto);
     var insert = await rep.InsertAsync(entity);
     uow.Commit();
     return true;

}

        ///<summary>
        /// 修改
        ///</summary>
public async Task<bool> UpdateApplicationUser (ApplicationUserDto dto){
   using var uow = _freeSql.CreateUnitOfWork();
        var rep = _freeSql.GetRepository<ApplicationUser>();
        rep.UnitOfWork = uow;
        var entity = _mapper.Map<ApplicationUser>(dto);
        rep.Update(entity);
        uow.Commit();
        return true;

}
        ///<summary>
        /// 删除
        ///</summary>
public async Task<bool> DeleteApplicationUser(List<Guid> ids){

      using var uow = _freeSql.CreateUnitOfWork();
      var rep = _freeSql.GetRepository<ApplicationUser>();
      rep.UnitOfWork = uow;
      await rep.DeleteAsync(x=>ids.Contains(x.Id));
      uow.Commit();
      return true;

}
        ///<summary>
        /// 分页查询
        ///</summary>
public async Task<ApplicationUserPageViewDto> QueryApplicationUserPage (ApplicationUserPageRequest request){

    var rep = _freeSql.GetRepository<ApplicationUser>();
    var datas =await rep.Select.IncludeMany(app=>app.Roles)

                 .WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy),x=>x.CreateBy.Contains(request.CreateBy))
.WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy),x=>x.UpdateBy.Contains(request.UpdateBy))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(!string.IsNullOrWhiteSpace(request.UserName),x=>x.UserName.Contains(request.UserName))
.WhereIf(!string.IsNullOrWhiteSpace(request.HashPassword),x=>x.HashPassword.Contains(request.HashPassword))
.WhereIf(request.Birthday != null ,x=>x.Birthday ==request.Birthday)
.WhereIf(request.Gender != null ,x=>x.Gender ==request.Gender)
.WhereIf(!string.IsNullOrWhiteSpace(request.Email),x=>x.Email.Contains(request.Email))
.WhereIf(!string.IsNullOrWhiteSpace(request.Phone),x=>x.Phone.Contains(request.Phone))

                 .Count(out var total)
                 .Page(request.PageNumber, request.PageSize)
                 .ToListAsync<ApplicationUserDto>();
    var page = new ApplicationUserPageViewDto(datas,total, request.PageNumber, request.PageSize);
    return page;

}

public async Task<ApplicationUserDto> QueryApplicationUser (ApplicationUserRequestDto request){

    var rep = _freeSql.GetRepository<ApplicationUser>();
    var res = await rep.Select.IncludeMany(app=>app.Roles)
.WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy),x=>x.CreateBy.Contains(request.CreateBy))
.WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy),x=>x.UpdateBy.Contains(request.UpdateBy))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(!string.IsNullOrWhiteSpace(request.UserName),x=>x.UserName.Contains(request.UserName))
.WhereIf(!string.IsNullOrWhiteSpace(request.HashPassword),x=>x.HashPassword.Contains(request.HashPassword))
.WhereIf(request.Birthday != null ,x=>x.Birthday ==request.Birthday)
.WhereIf(request.Gender != null ,x=>x.Gender ==request.Gender)
.WhereIf(!string.IsNullOrWhiteSpace(request.Email),x=>x.Email.Contains(request.Email))
.WhereIf(!string.IsNullOrWhiteSpace(request.Phone),x=>x.Phone.Contains(request.Phone))
.ToOneAsync<ApplicationUserDto>();
    return res;

}    }
}