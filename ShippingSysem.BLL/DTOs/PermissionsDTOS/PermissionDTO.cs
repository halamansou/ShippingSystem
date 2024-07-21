using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS
{
    public class PermissionDTO
    {
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public bool CanCreate { get; set; }


    }
}
