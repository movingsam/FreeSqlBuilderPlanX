using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Application.Entity
{
    public class ApplicationMenu : TreeEntityBase<ApplicationMenu, long, long?>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsHidden { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
    }
}