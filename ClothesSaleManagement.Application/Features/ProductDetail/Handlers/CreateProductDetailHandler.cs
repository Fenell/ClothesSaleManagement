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
    public class CreateProductDetailHandler : IRequestHandler<CreateProductDetailRequest, ProductDetailDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;

        public CreateProductDetailHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductDetailRepository productDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productDetailRepository = productDetailRepository;
        }

        public async Task<ProductDetailDto> Handle(CreateProductDetailRequest request, CancellationToken cancellationToken)
        {
            var productDetai = _mapper.Map<Domain.ProductDetail>(request.ProductDetailDto);
            var isExists = await _productDetailRepository.ExistsSize(productDetai.ProductId, productDetai.Size);
            if (isExists)
                throw new BadRequestException("Size already exists");

            await _unitOfWork.ProductDetailRepository.AddAsync(productDetai);
            await _unitOfWork.Save();

            return request.ProductDetailDto;
        }
    }
}
