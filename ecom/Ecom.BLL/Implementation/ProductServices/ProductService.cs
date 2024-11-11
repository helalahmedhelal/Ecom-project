using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.BLL.Interfaces.ProductInterfaces;
using Ecom.Core.Dtos.ProductDtos;
using Ecom.DAL.Data;
using Ecom.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom.BLL.Implementation.ProductServices
{
    public class ProductService : IProductInterface
    {
        private readonly ApplicationDbContext _cotext;

        public ProductService(ApplicationDbContext cotext)
        {
            _cotext = cotext;
        }

        public async Task<List<ProductDto>> ListProductAsync()
        {
            var products = await _cotext.Products.ToListAsync();

            var productDtos = products.Select(p => new ProductDto
            {
                
                ProductName = p.ProductName,
                Description = p.Description,
                Category = p.Category,
                // Add other properties as necessary
            }).ToList();

            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Product = await _cotext.Products.FindAsync(id);

            if(Product == null){
                return null;
            }

            var productDto = new ProductDto{

                ProductName = Product.ProductName,

                Description = Product.Description,

                Category = Product.Category,
            };

            return productDto;
        }

        public async Task<ProductDto> CreateProductAsync(Product product)
        {

            var createdProduct = await _cotext.Products.AddAsync(product);

            await _cotext.SaveChangesAsync();

            var productDto = new ProductDto{

                ProductName = createdProduct.Entity.ProductName,

                Description = createdProduct.Entity.Description,

                Category = createdProduct.Entity.Category,
            };
            
            return productDto;
        }

        public async Task<ProductDto> UpdateProductAsync(int id, ProductUpdateDto product)
        {
            var UpdatedProduct = await _cotext.Products.FindAsync(id);

            if(UpdatedProduct == null){
                return null;
            }

            if(product.Description != null){
                UpdatedProduct.Description = product.Description;
            }

            if(product.Category != null){
                UpdatedProduct.Category = product.Category;
            }

            await _cotext.SaveChangesAsync();

            var productDto = new ProductDto{

                ProductName = UpdatedProduct.ProductName,

                Description = UpdatedProduct.Description,

                Category = UpdatedProduct.Category,
            };
            
            return productDto;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {

            var DeletedProduct = await _cotext.Products.FindAsync(id);

            if(DeletedProduct == null){
                return false;
            }
            var product = _cotext.Products.Remove(DeletedProduct);

            await _cotext.SaveChangesAsync();

            return true;
        }
    }
}