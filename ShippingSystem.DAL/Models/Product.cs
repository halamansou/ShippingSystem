using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Weight { get; set; }


        [Required]
        public decimal Quantity { get; set; }

        [ForeignKey("order")]
        public int order_Id { get; set; }

        public Order order { get; set; }
    }
}
