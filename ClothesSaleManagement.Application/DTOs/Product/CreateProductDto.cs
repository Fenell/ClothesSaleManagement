using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using ClothesSaleManagement.Application.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace ClothesSaleManagement.Application.DTOs.Product
{
	public class CreateProductDto:BaseDto
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public IFormFile? ImgFile { get; set; }
		public Guid CategoryId { get; set; }
		public string ImageUrl { get; set; } = string.Empty;

	}
}
