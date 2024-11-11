using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ecom.DAL.Models
{
    [Table("Users")]
    public class AppUser : IdentityUser
    {
        public virtual Profile Profile{ get; set; } = new Profile();

        public virtual ICollection<Order> Orders{ get; set; } = new List<Order>();
        
    }
}