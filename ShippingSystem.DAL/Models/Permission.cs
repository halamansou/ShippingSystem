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
    public class Permission : IEntity
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Key]
        public int Id { get; set; }




        [ForeignKey("role")]
        public int RoleId { get; set; }
        public Role role { get; set; }

        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        public ExistedEntities Entity { get; set; }

        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public bool CanCreate { get; set; }


    }
}
