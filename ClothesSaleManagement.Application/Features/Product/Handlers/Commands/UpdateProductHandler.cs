using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Product.Requests.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Product.Handlers.Commands
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductRequest>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_productRepository = productRepository;
		}
		public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
			if (product == null)
				throw new NotFoundException(nameof(product), request.Id);

			_mapper.Map(request.UpdateProductDto, product);
			if (request.UpdateProductDto.ImgFile != null)
				product.ImageUrl = await _productRepository.UploadFileImg(request.UpdateProductDto.ImgFile);

			await _unitOfWork.ProductRepository.UpdateAsync(product);
			await _unitOfWork.Save();
		}
	}
}
