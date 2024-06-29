using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    //public enum StatusOptions
    //{
    //    Pending,
    //    Approved,
    //    Rejected
    //}
    public class Order : IEntity
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string ClientName { get; set; } = string.Empty;


        [Required]
        //[EnumDataType(typeof(StatusOptions))]
        public string Status { get; set; } = string.Empty;


        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal TotalWeight { get; set; }


        [Required]
        public string PhoneOne { get; set; } = string.Empty;

        public string? PhoneTwo { get; set; }


        public string? Email { get; set; }

        public string? Notes { get; set; }

        public decimal? ReceivedMoney { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public decimal? PaiedMoney { get; set; }

        public DateOnly? CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? DeliverydDate { get; set; }
        [Required]
        public string StreetAndVillage { get; set; } = string.Empty;

        [ForeignKey("StaffMemberAccount")]
        public int? StaffMemberID { get; set; }

        [ForeignKey("MerchantAccount")]
        public int? MerchantID { get; set; }
        [ForeignKey("DeliveryAccount")]
        public int? DeliveryID { get; set; }

        [ForeignKey("ShippingType")]
        public int? ShippingTypeID { get; set; }
        [ForeignKey("paymentType")]
        public int? PaymentTypeID { get; set; }

        [ForeignKey("government")]

        public int? GovernmentId { get; set; }

        [ForeignKey("city")]

        public int? CitytId { get; set; }
        public Account StaffMemberAccount { get; set; }
        public MerchantAccount MerchantAccount { get; set; }
        public DeliveryAccount DeliveryAccount { get; set; }

        public ShippingType ShippingType { get; set; }
        public PaymentType paymentType { get; set; }

        public Government government { get; set; }
        public City city { get; set; }
        public virtual List<Product>? Products { get; set; } = new List<Product>();


    }
}
