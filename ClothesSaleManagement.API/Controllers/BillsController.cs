using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.Features.Bill.Requests;
using ClothesSaleManagement.Application.Features.BillDetail.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BillsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BillsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await _mediator.Send(new GetBilListRequest());

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _mediator.Send(new GetBillRequest() { Id = id });

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post(BillCreateDto billCreateDto)
		{
			var result = await _mediator.Send(new CreateBillRequest() { BillCreateDto = billCreateDto });

			return Ok(result);
		}


		[HttpGet("bill-detail/{billId}")]
		public async Task<IActionResult> GetBillDetail(Guid billId)
		{
			var result = await _mediator.Send(new GetListBillDetailRequest() { BillId = billId });

			return Ok(result);
		}

		[HttpPost("bill-detail/{billId}")]
		public async Task<IActionResult> CreateBillDetal(Guid billId, List<BillDetailCreateDto> billDetailCreateDtos)
		{
			var result = await _mediator.Send(new CreateBillDetailRequest()
			{ BillDetailCreateDtos = billDetailCreateDtos, BillId = billId});

			return Ok(result);
		}

	}
}
