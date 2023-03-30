using Category.Domain.Common;

namespace Category.Domain.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
