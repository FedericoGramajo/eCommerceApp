using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.DTOs.Cart
{
    public class Checkout
    {
        [Required]
        public required Guid PaymentMethodId { get; set; }
        [Required]
        public required IEnumerable<ProcessCart> Carts { get; set; }
    }
}
