using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesSaleManagement.Application.DTOs.BillDetail
{
	public class BillDetailCreateDto
	{
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid ProductDetailId { get; set; }
		
		public decimal TotalMoney => Price * Quantity;
	}
}
