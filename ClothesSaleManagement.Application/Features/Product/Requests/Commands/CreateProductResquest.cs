using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Product;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Commands
{
	public record CreateProductResquest:IRequest<ProductDto>
	{
		public CreateProductDto CreateProductDto { get; set; } = null!;
	}
}
