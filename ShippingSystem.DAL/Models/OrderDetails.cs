using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class OrderDetails 
    {
        [ForeignKey("order")]
        public int OrderId { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }


        public Order order { get; set; }
        public Product product { get; set; }
    }
}
