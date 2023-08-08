using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.Features.Product.Requests.Commands;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain.Enums;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Handlers.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductResquest, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository, IProductDetailRepository productDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
        }

        public async Task<ProductDto> Handle(CreateProductResquest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Product>(request.CreateProductDto);
            product.CreatedDate = DateTime.Now;
            product.Status = Status.Active;
            if (request.CreateProductDto.ImgFile != null)
                product.ImageUrl = await _productRepository.UploadFileImg(request.CreateProductDto.ImgFile);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.Save();

            var productCreated = await _productRepository.GetAllProductWtihCategory(request.CreateProductDto.Id);

            return _mapper.Map<ProductDto>(productCreated);
        }
    }
}
