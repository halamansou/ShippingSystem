using ShippingSysem.BLL.DTOs.ProductDTOs;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public string ClientName { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalWeight { get; set; }
        public  string PhoneOne { get; set; }
        public  string PhoneTwo { get; set; }
        public  string Email { get; set; }
        public  string Notes { get; set; }
        public  string StreetAndVillage { get; set; }
        public  bool IfVillage { get; set; }
        public  int CityID { get; set; }
        public  int MerchantID { get; set; }
        public  int ShippingTypeID { get; set; }
        public  int PaymentTypeID { get; set; }
        public  int GovernmentId { get; set; }
        public  List<ProductCreateDTO> Products { get; set; }
    }
}
