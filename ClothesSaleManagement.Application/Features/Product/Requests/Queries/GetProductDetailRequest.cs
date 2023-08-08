using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Queries
{
	public record GetProductDetailRequest(Guid Id):IRequest<ProductDto>
	{
		
	}
}
