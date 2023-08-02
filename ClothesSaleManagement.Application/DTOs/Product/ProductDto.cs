using ClothesSaleManagement.Domain.Enums;
using ClothesSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Size;

namespace ClothesSaleManagement.Application.DTOs.Product
{
	public class ProductDto
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal CostPrice { get; set; }
		public int AvailableQuantity { get; set; }
		public string Description { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public Status Status { get; set; }
		public CategoryDto? CategoryDto { get; set; }
		public  SizeDto? Size { get; set; }
	}
}
