using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;

namespace eCommerceApp.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceRespond> AddAsync(CreateCategory category);
        Task<ServiceRespond> UpdateAsync(UpdateCategory category);
        Task<ServiceRespond> DeleteAsync(Guid id);
    }
}
