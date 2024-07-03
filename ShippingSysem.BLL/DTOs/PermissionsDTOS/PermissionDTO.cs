using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS
{
    public class PermissionDTO
    {
        public int entityId { get; set; }
        public string entityName { get; set; }
        public bool canRead { get; set; }
        public bool canWrite { get; set; }
        public bool canDelete { get; set; }
        public bool canCreate { get; set; }


    }
}
