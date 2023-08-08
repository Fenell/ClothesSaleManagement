using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Category.Request.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Category.Handler
{
    public class UpdateCategoryHandler:IRequestHandler<UpdateCategoryRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new NotFoundException(nameof(category), request.Id);

            _mapper.Map(request.CategoryDto, category);
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.Save();
        }
    }
}
