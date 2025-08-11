using eCommerceApp.Domain.Entities.Cart;

namespace eCommerceApp.Domain.Interfaces.Cart
{
    public interface ICart
    {
        Task<int> SaveCheckOutHistory(IEnumerable<Achieve> chekouts);
        Task<IEnumerable<Achieve>> GetAllCheckoutHistory();
    }
}
