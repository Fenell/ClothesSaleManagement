using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Category;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Request.Queries
{
	public record GetCategoryListRequest:IRequest<List<CategoryDto>>
	{
	}
}
