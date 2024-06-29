using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using ShippingSysem.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.Create
{
    public class CreateEmployeeDTO
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public string phone { get; set; }

        public int? BranchId { get; set; }
        public int? RoleId { get; set; }

        public bool Status { get; set; }





    }
}
