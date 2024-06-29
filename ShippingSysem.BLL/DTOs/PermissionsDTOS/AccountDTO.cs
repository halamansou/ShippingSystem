using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.PermissionsDTOS
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public List<PermissionDTO> Permissions { get; set; }
    }
}
