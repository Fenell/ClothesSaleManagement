using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.Features.Bill.Requests;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Bill.Handlers
{
	public class GetBillListHandler:IRequestHandler<GetBilListRequest, List<BillDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IBillDetailRepository _billDetailRepository;

		public GetBillListHandler(IUnitOfWork unitOfWork, IMapper mapper, IBillDetailRepository billDetailRepository)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_billDetailRepository = billDetailRepository;
		}
		public async Task<List<BillDto>> Handle(GetBilListRequest request, CancellationToken cancellationToken)
		{
			var listBills = await _unitOfWork.BillRepository.GetAllAsync();

			var	listBillDtos = _mapper.Map<List<BillDto>>(listBills);
			foreach (var item in listBillDtos)
			{
				var lstBillDetails = await _billDetailRepository.GetListBillDetail(item.Id);
				item.TotalPayment = lstBillDetails.Sum(c => c.Price * c.Quantity);
			}
			return  listBillDtos.OrderByDescending(c=>c.CreatedDate).ToList();
		}
	}
}
