using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Category.Request.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Handler
{
    public class GetCategoryDetailHandler:IRequestHandler<GetCategoryDetailRequest, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryDetailHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new NotFoundException(nameof(category), request.Id);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
