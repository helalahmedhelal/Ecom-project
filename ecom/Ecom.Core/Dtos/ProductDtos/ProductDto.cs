using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Core.Dtos.ProductDtos
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Category { get; set;} = string.Empty;
    }
}