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
	public class CreateBillDetailHandler:IRequestHandler<CreateBillDetailRequest, IEnumerable<BillDetailCreateDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IBillDetailRepository _billDetailRepository;

		public CreateBillDetailHandler(IUnitOfWork unitOfWork, IMapper mapper, IBillDetailRepository billDetailRepository)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_billDetailRepository = billDetailRepository;
		}

		public async Task<IEnumerable<BillDetailCreateDto>> Handle(CreateBillDetailRequest request, CancellationToken cancellationToken)
		{
			var billDetails = _mapper.Map<List<Domain.BillDetail>>(request.BillDetailCreateDtos);

			await _billDetailRepository.AddRangeBillDetail(request.BillId, billDetails);

			await _unitOfWork.Save();

			return request.BillDetailCreateDtos;
		}
	}
}
