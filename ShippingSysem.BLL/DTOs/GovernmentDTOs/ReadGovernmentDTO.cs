using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.GovernmentDTOs
{
	public class ReadGovernmentDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public bool Status { get; set; }
	}
}
