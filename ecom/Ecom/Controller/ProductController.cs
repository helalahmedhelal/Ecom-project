using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.BLL.Interfaces.ProductInterfaces;
using Ecom.Core.Dtos.ProductDtos;
using Ecom.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Ecom.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _product;

        public ProductController(IProductInterface product){

            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> List(){

            var products = await _product.ListProductAsync();

            if(products.Count<=0){
                return NoContent();
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var product = await _product.GetProductByIdAsync(id);

            if(product==null){


                return NotFound($"No such product wit thid id : {id}");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product){

            if(product==null){

                return BadRequest();

            }

            var createdProduct = await _product.CreateProductAsync(product);

            return Ok(createdProduct);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto product)
        {
            if(product==null){

                return BadRequest();
            }
            
            var updatedProduct = await _product.UpdateProductAsync(id, product);

            if(updatedProduct==null){

                return NotFound($"No such product with id : {id} to update it");
            }

            return Ok(updatedProduct);
                
        }

        [HttpDelete("{id}/delete")]

        public async Task<IActionResult> Delete(int id){

            var deletedProduct =  await _product.DeleteProductAsync(id);

            if(!deletedProduct){

                return NotFound($"No such product with this id : {id} to delete");
            }
            
            return NoContent();
        }

            
    }
        
}
