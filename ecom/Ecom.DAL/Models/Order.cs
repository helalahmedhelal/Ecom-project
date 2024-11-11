using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public string? OrderName { get; set; }

        [ForeignKey("User")]
        public string AppUserId { get; set; } = string.Empty;
        public virtual AppUser? User{ get; set; }

        public int ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}