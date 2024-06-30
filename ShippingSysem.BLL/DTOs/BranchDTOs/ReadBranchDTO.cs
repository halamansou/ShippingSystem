using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.BranchDTOs
{
	public class ReadBranchDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public bool Status { get; set; }
		public DateOnly CreatedDate { get; set; }
		public int? GovernmentID { get; set; }
		public string? GovernmentName { get; set; }
	}
}
