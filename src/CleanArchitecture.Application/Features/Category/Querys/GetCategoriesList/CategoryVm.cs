using CleanArchitecture.Application.Features.Common;

namespace CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList
{
    public class CategoryVm : BaseApplicationModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public int? ParentCategory { get; set; }
    }
}
