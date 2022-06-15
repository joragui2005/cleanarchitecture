namespace CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList
{
    public class CategoryVm
    {
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public int? ParentCategory { get; set; }
    }
}
