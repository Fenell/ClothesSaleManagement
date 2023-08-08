using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.Features.ProductDetail.Requests.Commands;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.ProductDetail.Handlers
{
	public class UpdateStockProductHandler : IRequestHandler<UpdateStockProductRequest>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateStockProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task Handle(UpdateStockProductRequest request, CancellationToken cancellationToken)
		{
			List<Domain.ProductDetail> lstProductDetails = new List<Domain.ProductDetail>();
			foreach (var item in request.ProductDetailDtos)
			{
				var productDetail = await _unitOfWork.ProductDetailRepository.GetByIdAsync(item.Id);
				productDetail.Stock -= item.Stock;
				lstProductDetails.Add(productDetail);
			}

			await _unitOfWork.ProductDetailRepository.UpdateRangeAsync(lstProductDetails);
			await _unitOfWork.Save();
		}
	}
}
