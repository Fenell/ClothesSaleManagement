using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.Features.BillDetail.Requests;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.BillDetail.Handlers
{
	public class GetListBillDetailHandler : IRequestHandler<GetListBillDetailRequest, IQueryable<BillDetailDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetListBillDetailHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IQueryable<BillDetailDto>> Handle(GetListBillDetailRequest request, CancellationToken cancellationToken)
		{
			var billQuery = await _unitOfWork.BillRepository.GetAllAsync();
			var billDetailQuery = await _unitOfWork.BillDetailRepository.GetAllAsync();
			var productDetailQuery = await _unitOfWork.ProductDetailRepository.GetAllAsync();
			var productQuery = await _unitOfWork.ProductRepository.GetAllAsync();

			var query = (from a in billDetailQuery
						 where a.BillId == request.BillId
						 join b in productDetailQuery on a.ProductDetailId equals b.Id
						 join c in productQuery on b.ProductId equals c.Id
						 join d in billQuery on a.BillId equals d.Id
						 select new BillDetailDto()
						 {
							 Id = a.Id,
							 ProductDetailId = b.Id,
							 NameProduct = c.Name,
							 Price = c.Price,
							 Size = b.Size,
							 Quantity = a.Quantity,
							 TotalMoney = a.TotalMoney,
							 BillId = d.Id,
						 });

			return query;
		}
	}
}
