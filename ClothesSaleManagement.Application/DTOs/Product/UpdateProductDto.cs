using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Common;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace ClothesSaleManagement.Application.DTOs.Product
{
	public class UpdateProductDto
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Description { get; set; } = string.Empty;
		public Status Status { get; set; }
		public IFormFile? ImgFile { get; set; }
		public Guid CategoryId { get; set; }

	}
}
