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
    public class Branch : IEntity,IStatus
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        public bool Status { get; set; }
		public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [ForeignKey("Government")]
        public int GovernmentID { get; set; }

        public Government Government { get; set; }

        public virtual List<Account>? Accounts { get; set; } = new List<Account>();

    }
}
