using System.ComponentModel.DataAnnotations;
namespace eCommerceApp.Application.DTOs.Cart
{
    public class CreateAchieve
    {
        [Required]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? UserId { get; set; }
    }
}
