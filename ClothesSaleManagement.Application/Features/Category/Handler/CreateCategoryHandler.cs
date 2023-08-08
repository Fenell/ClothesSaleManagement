using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Category.Request.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Handler
{
    public class CreateCategoryHandler:IRequestHandler<CreateCategoryRequest, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Category>(request.CategoryDto);
            if (category == null)
                throw new BadRequestException("Category empty");

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.Save();

            return request.CategoryDto;
        }
    }
}
