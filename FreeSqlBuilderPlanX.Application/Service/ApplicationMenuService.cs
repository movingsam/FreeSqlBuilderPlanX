//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Datas.Extensions;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.Service
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationMenuService : ServiceBase<ApplicationMenu, ApplicationContext>, IApplicationMenuIService
    {
        private readonly IFreeSql<ApplicationContext> _freeSql;
        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationMenuService(IServiceProvider service, ILogger<ApplicationMenuService> logger) : base(service, logger)
        {
            _freeSql = service.GetService<IFreeSql<ApplicationContext>>();
        }


        ///<summary>
        /// 新增
        ///</summary>
        public async Task<bool> NewApplicationMenu(ApplicationMenuRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationMenu>(dto);
            await Repository.TreeInsertAsync<ApplicationMenu, long, long?>(entity);
            await UowManager.CommitAsync();
            return true;
        }

        ///<summary>
        /// 修改
        ///</summary>
        public async Task<bool> UpdateApplicationMenu(long id, ApplicationMenuRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationMenu>(dto);
            await Repository.TreeUpdateAsync<ApplicationMenu, long, long?>(id, entity);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 删除
        ///</summary>
        public async Task<bool> DeleteApplicationMenu(long id)
        {
            await Repository.DeleteAsync(x => x.Id == id);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 分页查询
        ///</summary>
        public async Task<ApplicationMenuPageViewDto> QueryApplicationMenuPage(ApplicationMenuPageRequest request)
        {
            var datas = await Repository
                                .Select
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), x => x.Name.Contains(request.Name))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Title), x => x.Title.Contains(request.Title))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Icon), x => x.Icon.Contains(request.Icon))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Path), x => x.Path.Contains(request.Path))
                                .OrderByPropertyName(request.OrderParam.PropertyName, request.OrderParam.IsAscending)
                                .Count(out var total)
                                .Page(request.PageNumber, request.PageSize)
                                .ToTreeListAsync();
            var views = Mapper.Map<List<ApplicationMenuDto>>(datas);
            var page = new ApplicationMenuPageViewDto(views, request, total);
            return page;
        }


        ///<summary>
        /// 查询
        ///</summary>
        public async Task<ApplicationMenuDto> QueryApplicationMenu(long Id)
        {
            var data = await Repository
                .Select
                .GetSingleTreeAsync<ApplicationMenu, long, long?>(Id);
            var view = Mapper.Map<ApplicationMenuDto>(data);
            return view;
        }
    }
}