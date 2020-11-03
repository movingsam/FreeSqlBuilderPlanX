using System.ComponentModel;

namespace GIMS.Infrastructure.Cache
{
    public static class CacheKeyTemplate
    {
        /// <summary>
        /// 组织机构缓存
        /// </summary>
        [Description("全局-组织机构缓存")]
        public const string GroupList = "admin:GroupList";

        /// <summary>
        /// 权限模板菜单资源缓存 admin:Permission:权限模板主键:ResourceList
        /// </summary>
        [Description("权限模板-资源集合缓存")]
        public const string PermissionResourceList = "admin:Permission:{0}:ResourceList";

        /// <summary>
        /// 用户登录后缓存用户信息 session:User:用户主键:UserInfo
        /// </summary>
        [Description("会话模板-用户信息")]
        public const string UserSession = "session:User:{0}:UserInfo";

        /// <summary>
        /// 权限模板Api缓存 admin:Permission:权限模板主键:ApiList
        /// </summary>
        [Description("权限模板-Api集合缓存")]
        public const string PermissionApiList = "admin:Permission:{0}:ApiList";
        /// <summary>
        /// 部门模板-部门树
        /// </summary>
        [Description("部门模板-部门树")]
        public const string DepartmentTree = "admin:DepartmentTree";
        /// <summary>
        /// 部门模板-部门列表
        /// </summary>
        [Description("部门模板-部门列表")]
        public const string DepartmentList = "admin:DepartmentList";

    }
}