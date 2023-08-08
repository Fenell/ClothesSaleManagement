using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Product.Requests.Queries;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Queries;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Handlers
{
	public class GetOnProductDetailHandler:IRequestHandler<GetOnProductDetailRequest, ProductDetailDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetOnProductDetailHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ProductDetailDto> Handle(GetOnProductDetailRequest request, CancellationToken cancellationToken)
		{
			var productDetail = await _unitOfWork.ProductDetailRepository.GetByIdAsync(request.Id);

			if (productDetail == null)
				throw new NotFoundException(nameof(productDetail), request.Id);

			var productDetailDto = _mapper.Map<ProductDetailDto>(productDetail);

			return productDetailDto;
		}
	}
}
