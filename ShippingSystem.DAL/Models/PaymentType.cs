using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class PaymentType : IEntity
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public List<Order> orders { get; set; } = new List<Order>();
    }
}
