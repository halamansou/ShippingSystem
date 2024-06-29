using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS
{
    public class ReadEntitiesPermissionsDTO
    {
        public int Permission_id { get; set; }
        public int Entity_id { get; set; }
        public int User_id { get; set; }
        public string EntityName { get; set; }


    }
}
