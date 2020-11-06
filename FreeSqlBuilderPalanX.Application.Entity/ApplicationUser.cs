﻿using FreeSql.DataAnnotations;
using FreeSqlBuilderPlanX.Core;
using FreeSqlBuilderPlanX.Core.Base;
using System;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Application.Entity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class ApplicationUser : AuditEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码hash后
        /// </summary>
        public string HashPassword { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        [Navigate(ManyToMany = typeof(UserRole))]
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }

   
}