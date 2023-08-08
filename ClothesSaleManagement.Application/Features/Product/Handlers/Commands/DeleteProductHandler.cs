using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Product.Requests.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Handlers.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            await _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.Save();
        }
    }
}
