using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.RoleDTOS
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateOnly? CreatedDate { get; set; }
    }
}
