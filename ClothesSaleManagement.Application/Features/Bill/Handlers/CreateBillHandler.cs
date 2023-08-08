using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.Features.Bill.Requests;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain.Enums;
using MediatR;

namespace ClothesSaleManagement.Application.Features.Bill.Handlers
{
	public class CreateBillHandler:IRequestHandler<CreateBillRequest, Guid>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateBillHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Guid> Handle(CreateBillRequest request, CancellationToken cancellationToken)
		{
			var bill =  _mapper.Map<Domain.Bill>(request.BillCreateDto);

			bill.Id = Guid.NewGuid();
			bill.CreatedDate = DateTime.Now;
			bill.Status = BillStatus.Paid;

			var billCreated = await _unitOfWork.BillRepository.AddAsync(bill);
			await _unitOfWork.Save();

			return bill.Id;
		}
	}
}
