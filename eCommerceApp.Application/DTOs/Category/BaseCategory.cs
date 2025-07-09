using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.Category
{
    public class BaseCategory
    {
        [Required]
        public string? Name { get; set; }

    }
}
