using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingSystem.DAL.Models.Base;
using System.ComponentModel;

namespace ShippingSystem.DAL.Models
{
    public class City : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool Status { get; set; }



        [ForeignKey("Government")]
        public int? GovernmentID { get; set; }

        public Government Government { get; set; }
    }
}
