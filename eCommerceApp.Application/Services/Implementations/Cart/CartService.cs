using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Application.Services.Interfaces.Cart;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Domain.Interfaces.Cart;

namespace eCommerceApp.Application.Services.Implementations.Cart
{
    public class CartService(ICart cartInterface, IMapper mapper, IGeneric<Product> productInterface, 
        IPaymentMethodService paymentMethod, IPaymentService paymentService) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var (product, totalAmount) = await GetTotalAmount(checkout.Carts);
            var paymentMethods = await paymentMethod.GetPaymentMethod();

            if(checkout.PaymentMethodId == paymentMethods.FirstOrDefault()!.Id)
                return await paymentService.Pay(totalAmount, product, checkout.Carts);
            else
                return new ServiceResponse(false, "Invalid payment method");
        }

        public async Task<ServiceResponse> SaveCheckOutHistory(IEnumerable<CreateAchieve> achieves)
        {
            var mappedData = mapper.Map<IEnumerable<Achieve>>(achieves);
            var result = await cartInterface.SaveCheckOutHistory(mappedData);

            return result > 0 ? new ServiceResponse(true, "Checkout achieved") : new ServiceResponse(false, "Error ocurred in saving");
        }

        private async Task<(IEnumerable<Product>, decimal)> GetTotalAmount(IEnumerable<ProcessCart> carts)
        {
            if (!carts.Any()) return ([], 0);

            var products = await productInterface.GetAllAsync();
            if(!products.Any()) return ([], 0);

            var cartProducts = carts
                .Select(cartItem => products.FirstOrDefault(p => p.Id == cartItem.ProductId))
                .Where(product => product != null)
                .ToList();

            var totalAmount = carts
                .Where(cartItem => cartProducts.Any(p => p.Id == cartItem.ProductId))
                .Sum(cartItem => cartItem.Quantity * cartProducts.First(p => p.Id == cartItem.ProductId)!.Price);

            return (cartProducts!, totalAmount);
        }
    }
}
