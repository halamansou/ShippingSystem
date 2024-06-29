using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Permission_User_Entities
    {
        [ForeignKey("account")]
        public int user_id { get; set; }

        [ForeignKey("permission")]
        public int permission_id { get; set; }

        [ForeignKey("entity")]
        public int entity_id { get; set; }

        public Account account { get; set; }
        public Permission permission { get; set; }
        public AccessedEntity entity { get; set; }
    }
}
