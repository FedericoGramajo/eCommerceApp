using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace eCommerceApp.Application.DTOs.Category
{
    public class UpdateCategory : BaseCategory
    {
        [Required]
        public Guid Id { get; set; }
    }
}
