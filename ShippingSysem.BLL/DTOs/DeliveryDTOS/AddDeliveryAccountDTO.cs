using System.ComponentModel.DataAnnotations;

namespace ShippingSysem.BLL.DTOs.DeliveryDTOS
{
    public class AddDeliveryAccountDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Governments { get; set; }

        [Required]
        public int Branch { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Discount_type { get; set; }

        [Required]
        public decimal Company_Percantage { get; set; }
    }
}
