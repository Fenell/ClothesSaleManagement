using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Product.Requests.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;
using ProductDetailDto = ClothesSaleManagement.Application.DTOs.ProductDetail.ProductDetailDto;

namespace ClothesSaleManagement.Application.Features.Product.Handlers.Queries
{
    public class GetProductDetailHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;

        public GetProductDetailHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IProductDetailRepository productDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _productDetailRepository = productDetailRepository;
        }
        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllProductWtihCategory(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            var productDto = _mapper.Map<ProductDto>(product);

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(product.CategoryId);
            productDto.CategoryDto = _mapper.Map<CategoryDto>(category);

            var productDetails = await _productDetailRepository.GetProductDetail(request.Id);
            productDto.ProductDetailDtos = _mapper.Map<List<ProductDetailDto>>(productDetails);

            return productDto;
        }
    }
}
