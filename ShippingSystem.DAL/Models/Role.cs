using Microsoft.AspNetCore.Identity;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Role : IdentityRole<int>, IEntity
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateOnly? CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public virtual List<Account>? Accounts { get; set; } = new List<Account>();

        public virtual List<Permission>? Permissions { get; set; } = new List<Permission>();

    }
}
