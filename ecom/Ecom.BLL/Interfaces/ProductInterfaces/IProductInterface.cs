using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Core.Dtos.ProductDtos;
using Ecom.DAL.Models;

namespace Ecom.BLL.Interfaces.ProductInterfaces
{
    public interface IProductInterface
    {
        public Task<List<ProductDto>> ListProductAsync();

        public Task<ProductDto> GetProductByIdAsync(int id);

        public Task<ProductDto> CreateProductAsync(Product product);

        public Task<ProductDto> UpdateProductAsync(int id, ProductUpdateDto product);

        public Task<bool> DeleteProductAsync(int id);
    }
}