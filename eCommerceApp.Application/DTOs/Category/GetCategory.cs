using eCommerceApp.Application.DTOs.Product;

namespace eCommerceApp.Application.DTOs.Category
{
    public class GetCategory : BaseCategory
    {
        public Guid Id { get; set; }
        public ICollection<GetProduct>? Products { get; set; }
    }
}
