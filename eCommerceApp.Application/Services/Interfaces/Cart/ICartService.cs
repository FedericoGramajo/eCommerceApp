using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Cart;

namespace eCommerceApp.Application.Services.Interfaces.Cart
{
    public interface ICartService
    {
        Task<ServiceResponse> SaveCheckOutHistory(IEnumerable<CreateAchieve> achieves);
        Task<ServiceResponse> Checkout(Checkout checkout);
        Task<IEnumerable<GetAchieve>> GetAchives();
    }
}
