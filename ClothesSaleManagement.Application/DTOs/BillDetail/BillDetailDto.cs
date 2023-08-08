using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.Common;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Application.DTOs.BillDetail
{
	public class BillDetailDto:BaseDto
	{
		public string NameProduct { get; set; }
		public string NameCategory { get; set; }
		public Size Size { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal TotalMoney { get; set; }
		public Guid ProductDetailId { get; set; }
		public Guid BillId { get; set; }
	
	}

	
}
