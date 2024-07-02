using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{    
    //table to add special offer when add Merchant Account 
    public class SpecialOffer : IEntity
    {
        public int Id {  get; set; }
        public bool IsDeleted { get; set; }
        public string Government { get; set; }
        public string City { get; set; }

        [ForeignKey("MerchantAccount")]
        public int MerchantId { get; set; }

    }
}
