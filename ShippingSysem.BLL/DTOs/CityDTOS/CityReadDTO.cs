using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.CityDTOS
{
    public class CityReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public bool Status { get; set; }

        public decimal NormalShippingCost { get; set; }
        public decimal PickupShippingCost { get; set; }
        public int GovernmentID { get; set; }
        public string GovernmentName { get; set; }
    }
}
