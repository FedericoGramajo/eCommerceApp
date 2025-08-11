using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentMethodService paymentmethodService) : ControllerBase
    {
        [HttpGet("methods")]
        public async Task<ActionResult<IEnumerable<GetPaymentMethod>>> GetPaymentMethods()
        {
           var methods = await paymentmethodService.GetPaymentMethod();
            if (!methods.Any())
                return BadRequest(NotFound());
            else
                return Ok(methods);
        }

    }
}
