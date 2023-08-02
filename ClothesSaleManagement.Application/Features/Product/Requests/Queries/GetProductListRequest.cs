using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Product;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Queries
{
	public record GetProductListRequest:IRequest<List<ProductDto>>
	{
	}
}
