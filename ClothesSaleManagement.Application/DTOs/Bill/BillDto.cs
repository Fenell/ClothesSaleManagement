using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.Common;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Application.DTOs.Bill
{
	public class BillDto:BillCreateDto
	{
		public DateTime CreatedDate { get; set; }
		public BillStatus Status { get; set; }
	}

	public class BillCreateDto:BaseDto
	{
		public decimal TotalPayment { get; set; }
		public string CustomerName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;


	}
}
