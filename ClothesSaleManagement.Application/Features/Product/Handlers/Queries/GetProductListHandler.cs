using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Features.Product.Requests.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;
using ProductDetailDto = ClothesSaleManagement.Application.DTOs.ProductDetail.ProductDetailDto;

namespace ClothesSaleManagement.Application.Features.Product.Handlers.Queries
{
    public class GetProductListHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var listProductDetails = await _productRepository.GetAllProductWtihCategory();
            var listProductDto = _mapper.Map<List<ProductDto>>(listProductDetails);

            foreach (var productDto in listProductDto)
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(productDto.CategoryId);
                productDto.CategoryDto = _mapper.Map<CategoryDto>(category);
            }

            return listProductDto;
        }
    }
}
