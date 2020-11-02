//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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
            var dbSet = _freeSql.CreateDbContext().Set<ApplicationUser>();
            await Repository.InsertAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }

        ///<summary>
        /// 修改
        ///</summary>
        public async Task<bool> UpdateApplicationMenu(ApplicationMenuRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationMenu>(dto);
            await Repository.UpdateAsync(entity);
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
                                .WhereIf(request.ParentId != null, x => x.ParentId == request.ParentId)
                                .WhereIf(!string.IsNullOrWhiteSpace(request.NodePath), x => x.NodePath.Contains(request.NodePath))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), x => x.Name.Contains(request.Name))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Title), x => x.Title.Contains(request.Title))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Icon), x => x.Icon.Contains(request.Icon))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Path), x => x.Path.Contains(request.Path))
                                .Count(out var total)
                                .Page(request.PageNumber, request.PageSize)
                                .ToListAsync();
            var views = Mapper.Map<List<ApplicationMenuDto>>(datas);
            var page = new ApplicationMenuPageViewDto(views, total, request.PageNumber, request.PageSize);
            return page;
        }


        ///<summary>
        /// 查询
        ///</summary>
        public async Task<ApplicationMenuDto> QueryApplicationMenu(long Id)
        {
            var data = await Repository.Select
                                       .Where(x => x.Id == Id)
                                       .ToOneAsync();
            var view = Mapper.Map<ApplicationMenuDto>(data);
            return view;
        }
    }
}