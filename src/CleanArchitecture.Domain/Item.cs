using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Item : BaseDomainModel
    {
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}