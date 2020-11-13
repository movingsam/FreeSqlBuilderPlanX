//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-12 17:28
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPlanX.Core.Base;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    public class ApplicationMenuDto : DtoBase<long>
    {
            public int Level { get; set; }
            public long? ParentId { get; set; }
            public ApplicationMenuDto Parent { get; set; }
            public ICollection<ApplicationMenuDto> Children { get; set; }
            public string NodePath { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public bool IsHidden { get; set; }
            public string Icon { get; set; }
            public string Path { get; set; }
    }
}