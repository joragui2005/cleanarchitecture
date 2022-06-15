using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Category : BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public int? ParentCategory { get; set; }
        public IEnumerable<Item>? Items { get; set; }
    }
}