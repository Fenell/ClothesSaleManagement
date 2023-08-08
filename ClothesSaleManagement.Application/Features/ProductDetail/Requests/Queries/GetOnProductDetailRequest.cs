using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Requests.Queries
{
	public class GetOnProductDetailRequest:IRequest<ProductDetailDto>
	{
		public Guid Id { get; set; }
	}
}
