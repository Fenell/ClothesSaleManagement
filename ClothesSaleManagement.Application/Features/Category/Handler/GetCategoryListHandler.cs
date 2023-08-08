using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.Features.Category.Request.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Handler
{
	public class GetCategoryListHandler:IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetCategoryListHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
		{
			var listCategories = await _unitOfWork.CategoryRepository.GetAllAsync();

			return _mapper.Map<List<CategoryDto>>(listCategories);
		}


	}
}
