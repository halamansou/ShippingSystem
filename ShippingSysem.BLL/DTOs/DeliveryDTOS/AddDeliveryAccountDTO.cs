using System.ComponentModel.DataAnnotations;

namespace ShippingSysem.BLL.DTOs.DeliveryDTOS
{
    public class AddDeliveryAccountDTO
    {

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string UserName { get; set; }

       
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Governments { get; set; }

        [Required]
        public int Branch { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Discount_type { get; set; }

        [Required]
        public decimal Company_Percantage { get; set; }
    }
}
