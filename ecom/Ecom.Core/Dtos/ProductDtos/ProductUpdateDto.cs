using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Core.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(50)]
        public string Category { get; set;} = string.Empty;
    }
}