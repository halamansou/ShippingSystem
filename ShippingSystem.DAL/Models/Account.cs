using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShippingSystem.DAL.Models.Base;

namespace ShippingSystem.DAL.Models
{
    public class Account : IdentityUser<int>, IEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public bool Status { get; set; }

        [ForeignKey("Role")]
        public int? RoleID { get; set; }

        public Role Role { get; set; }

        [ForeignKey("Branch")]
        public int? BranchID { get; set; }

        public Branch Branch { get; set; }

        public virtual List<Order>? Orders { get; set; } = new List<Order>();

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
