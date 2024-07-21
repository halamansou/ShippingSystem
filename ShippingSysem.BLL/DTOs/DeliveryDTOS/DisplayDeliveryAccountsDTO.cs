using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.DeliveryDTOS
{
    public class DisplayDeliveryAccountsDTO
    {

        public string UserName { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public string Branch { get; set; } 
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public decimal DiscountType { get; set; }

    }
}
