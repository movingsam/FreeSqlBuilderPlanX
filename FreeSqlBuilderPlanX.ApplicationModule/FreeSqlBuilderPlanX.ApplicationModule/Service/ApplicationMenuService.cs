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
public class ApplicationMenuService {
        private readonly IFreeSql _freeSql;
        private readonly ILogger<ApplicationMenuService> _logger;
        private readonly IMapper _mapper;

        ///<summary>
        /// 构造函数
        ///</summary>
    public ApplicationMenuService(IServiceProvider service,ILogger<ApplicationMenuService>
    logger) {
    this._freeSql = service.GetService<IFreeSql>();
    _logger = logger;
    _mapper = service.GetService<IMapper>();
    }


        ///<summary>
        /// 新增
        ///</summary>
public async Task<bool> NewApplicationMenuService (ApplicationMenuDto dto){

     using var uow = _freeSql.CreateUnitOfWork();
     var rep = _freeSql.GetRepository<ApplicationMenu>();
     rep.UnitOfWork = uow;
     var entity = _mapper.Map<ApplicationMenu>(dto);
     var insert = await rep.InsertAsync(entity);
     uow.Commit();
     return true;

}

        ///<summary>
        /// 修改
        ///</summary>
public async Task<bool> UpdateApplicationMenu (ApplicationMenuDto dto){
   using var uow = _freeSql.CreateUnitOfWork();
        var rep = _freeSql.GetRepository<ApplicationMenu>();
        rep.UnitOfWork = uow;
        var entity = _mapper.Map<ApplicationMenu>(dto);
        rep.Update(entity);
        uow.Commit();
        return true;

}
        ///<summary>
        /// 删除
        ///</summary>
public async Task<bool> DeleteApplicationMenu(List<long> ids){

      using var uow = _freeSql.CreateUnitOfWork();
      var rep = _freeSql.GetRepository<ApplicationMenu>();
      rep.UnitOfWork = uow;
      await rep.DeleteAsync(x=>ids.Contains(x.Id));
      uow.Commit();
      return true;

}
        ///<summary>
        /// 分页查询
        ///</summary>
public async Task<ApplicationMenuPageViewDto> QueryApplicationMenuPage (ApplicationMenuPageRequest request){

    var rep = _freeSql.GetRepository<ApplicationMenu>();
    var datas =await rep.Select
                 .WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(request.Level != null ,x=>x.Level ==request.Level)
.WhereIf(request.ParentId != null ,x=>x.ParentId ==request.ParentId)
.WhereIf(!string.IsNullOrWhiteSpace(request.NodePath),x=>x.NodePath.Contains(request.NodePath))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(request.Enabled != null ,x=>x.Enabled ==request.Enabled)

                 .Count(out var total)
                 .Page(request.PageNumber, request.PageSize)
                 .ToListAsync<ApplicationMenuDto>();
    var page = new ApplicationMenuPageViewDto(datas,total, request.PageNumber, request.PageSize);
    return page;

}

public async Task<ApplicationMenuDto> QueryApplicationMenu (ApplicationMenuRequestDto request){

    var rep = _freeSql.GetRepository<ApplicationMenu>();
    var res = await rep.Select.WhereIf(request.Id != null ,x=>x.Id ==request.Id)
.WhereIf(request.Version != null ,x=>x.Version ==request.Version)
.WhereIf(request.Level != null ,x=>x.Level ==request.Level)
.WhereIf(request.ParentId != null ,x=>x.ParentId ==request.ParentId)
.WhereIf(!string.IsNullOrWhiteSpace(request.NodePath),x=>x.NodePath.Contains(request.NodePath))
.WhereIf(request.IsDeleted != null ,x=>x.IsDeleted ==request.IsDeleted)
.WhereIf(request.Enabled != null ,x=>x.Enabled ==request.Enabled)
.ToOneAsync<ApplicationMenuDto>();
    return res;

}    }
}