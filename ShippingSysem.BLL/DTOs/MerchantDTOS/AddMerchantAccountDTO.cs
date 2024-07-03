using ShippingSystem.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace ShippingSysem.BLL.DTOs.MerchantDTOS
{
    public class AddMerchantAccountDTO
    {
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Branch is required")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Store name is required")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Government is required")]
        public string Government { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pickup price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Pickup price must be a positive value")]
        public decimal Pickup_Price { get; set; }

        [Required(ErrorMessage = "Refund percentage is required")]
        [Range(0, 100, ErrorMessage = "Refund percentage must be between 0 and 100")]
        public decimal Refund_Percentage { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
    }
}
