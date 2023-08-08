using ClothesSaleManagement.Domain.Enums;
using ClothesSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Common;
using ClothesSaleManagement.Application.DTOs.ProductDetail;

namespace ClothesSaleManagement.Application.DTOs.Product
{
	public class ProductDto : BaseDto
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public Status Status { get; set; }
		public Guid CategoryId { get; set; }
		public CategoryDto? CategoryDto { get; set; }
		public IEnumerable<ProductDetailDto>? ProductDetailDtos { get; set; }
	}
}
