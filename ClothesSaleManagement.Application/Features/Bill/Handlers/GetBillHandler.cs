using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.Exceptions;
using ClothesSaleManagement.Application.Features.Bill.Requests;
using ClothesSaleManagement.Application.Repositories;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Bill.Handlers
{
	public class GetBillHandler:IRequestHandler<GetBillRequest, BillDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IBillRepository _billRepository;

		public GetBillHandler(IUnitOfWork unitOfWork, IMapper mapper, IBillRepository billRepository)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_billRepository = billRepository;
		}
		public async Task<BillDto> Handle(GetBillRequest request, CancellationToken cancellationToken)
		{
			var bill = await _unitOfWork.BillRepository.GetByIdAsync(request.Id);

			if (bill == null)
				throw new NotFoundException(nameof(bill), request.Id);
			
			var billDto = _mapper.Map<BillDto>(bill);

			return billDto;
		}
	}
}
