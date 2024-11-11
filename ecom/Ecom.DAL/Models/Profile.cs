using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecom.DAL.Models
{
    [Table("Profiles")]
    public class Profile
    {
        public int Id { get; set; }

        public string Status { get; set;}=string.Empty;

        public string Bio { get; set; }=string.Empty;

        [ForeignKey("User")]
        public string AppUserId { get; set; } = string.Empty;

        public virtual AppUser User { get; set; } = new AppUser();
    }
}