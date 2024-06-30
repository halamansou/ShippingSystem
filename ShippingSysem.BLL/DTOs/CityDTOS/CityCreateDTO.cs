using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.CityDTOS
{
    public class CityCreateDTO
    {
        public string Name { get; set; } 
        public bool Status { get; set; }

        public decimal NormalShippingCost { get; set; }
        public decimal PickupShippingCost { get; set; }

        public int? GovernmentID { get; set; }
    }
}
