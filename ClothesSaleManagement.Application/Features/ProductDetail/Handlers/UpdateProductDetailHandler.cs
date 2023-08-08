using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Handlers
{
    public class UpdateProductDetailHandler : IRequestHandler<UpdateProductDetailRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IMapper _mapper;

        public UpdateProductDetailHandler(IUnitOfWork unitOfWork, IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateProductDetailRequest request, CancellationToken cancellationToken)
        {
            var productDetail = await _unitOfWork.ProductDetailRepository.GetByIdAsync(request.Id);

            if (productDetail == null)
                throw new NotFoundException(nameof(productDetail), request.Id);

            productDetail.Stock += request.AddedQuantity;
            await _unitOfWork.ProductDetailRepository.UpdateAsync(productDetail);
            await _unitOfWork.Save();
        }
    }
}
