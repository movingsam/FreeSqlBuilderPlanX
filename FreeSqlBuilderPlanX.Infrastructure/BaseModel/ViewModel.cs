using System;
using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using FreeSqlBuilderPlanX.Core;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Utils;

namespace FreeSqlBuilderPlanX.Infrastructure.BaseModel
{
    public class ViewModel : TreeEntityBase<ViewModel, int, int?>
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 页面路由名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 页面路由地址
        /// </summary>
        public string RoutePath { get; set; }
        /// <summary>
        /// 是否隐藏 （不在目录导航栏显示）
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary>
        /// 标题元属性
        /// </summary>
        [Column(IsIgnore = true)]
        public ViewMate Mate { get;private set; }
        /// <summary>
        /// Mate持久化用字符串
        /// </summary>
        public string MateJson
        {
            get => Mate.ToJson();
            set => Mate = value.ToObject<ViewMate>();
        }


    }
    public class ViewMate
    {
        public string Icon { get; set; }
        public string Title { get; set; }
    }
}