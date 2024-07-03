using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.MerchantDTOS
{
    public class DisplayMerchantAccountsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string Branch { get; set; }

        public string Address { get; set; }

        public string StoreName { get; set; }

        public string Phone { get; set; }
        public string Government { get; set; }
        public string City { get; set; }
        public decimal Pickup_Price { get; set; }
        public decimal Refund_Percentage { get; set; }



    }

}
