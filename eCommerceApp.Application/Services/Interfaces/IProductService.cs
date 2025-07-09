using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<GetProduct>> GetAllAsync();
        Task<GetProduct> GetByIdAsync(Guid id);
        Task<ServiceRespond> AddAsync(CreateProduct product);
        Task<ServiceRespond> UpdateAsync(UpdateProduct product);
        Task<ServiceRespond> DeleteAsync(Guid id);
    }
}
