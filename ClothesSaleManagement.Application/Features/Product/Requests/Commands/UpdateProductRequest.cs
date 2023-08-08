using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Product;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Requests.Commands
{
	public class UpdateProductRequest:IRequest
	{
		public Guid Id { get; set; }
		public UpdateProductDto UpdateProductDto { get; set; } = null!;
	}
}
