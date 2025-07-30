using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Implementations
{
    public class ProductService(IGeneric<Product> productInterface, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product created!") : new ServiceResponse(false, "Product failed to be create!");

        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await productInterface.DeleteAsync(id);
            return result > 0 ? new ServiceResponse(true, "Product deleted!") : new ServiceResponse(false, "Product not found or failed to be deleted!");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var rawData= await productInterface.GetAllAsync();
            return !rawData.Any() ? [] : mapper.Map<IEnumerable<GetProduct>>(rawData);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var rawData = await productInterface.GetByIdAsync(id);
            return rawData == null ? new GetProduct() : mapper.Map<GetProduct>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product updated!") : new ServiceResponse(false, "Product failed to be update!");
        }
    }
}
