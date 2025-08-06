using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Entities.Cart
{
    public class Achieve
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedData { get; set; } = DateTime.Now;
    }
}
