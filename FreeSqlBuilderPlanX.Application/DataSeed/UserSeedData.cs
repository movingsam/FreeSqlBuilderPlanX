using System;
using FreeSql;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Core;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Application.DataSeed
{
    public class ApplicationSeedData
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IFreeSql<ApplicationContext> _dbContext;
        private readonly IBaseRepository<ApplicationUser> _userRep;
        private readonly IBaseRepository<Role> _roleRep;
        private readonly IUnitOfWorkManager _uow;
        public ApplicationSeedData(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _dbContext = _serviceProvider.GetService<IFreeSql<ApplicationContext>>();
            _userRep = _dbContext.GetRepository<ApplicationUser>();
            _roleRep = _dbContext.GetRepository<Role>();
            _uow = _serviceProvider.GetService<IUnitOfWorkManager>();
        }

        public void SeedRole()
        {
            if (!_roleRep.Select.Any(x => x.Code == "admin"))
            {
                var admin = new Role
                {
                    Name = "超级管理员",
                    Code = "admin",
                    Descriptions = "系统自动创建种子数据 超级管理员 拥有所有权限"
                };
                _roleRep.Insert(admin);
            }
        }
        public void SeedUser()
        {
            if (!_userRep.Select.Any(x => x.UserName == "admin"))
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    HashPassword = "admin".GetMd5Hash(),
                    Gender = Gender.Male,
                    Birthday = DateTime.Today,
                    Email = "admin@admin.com",
                    Phone = "12345678901"
                };
                var adminRole = _roleRep.Select.Where(x => x.Code == "admin").ToOne();
                admin.Roles.Add(adminRole);
                _userRep.Insert(admin);
                _userRep.SaveMany(admin, nameof(ApplicationUser.Roles));
            }
        }

        public void Commit()
        {
            _uow.Commit();

        }
    }
}