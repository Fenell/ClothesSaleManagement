using ClothesSaleManagement.Application.DTOs.Category;
using ClothesSaleManagement.WebApp.Services.Bill;
using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BillController : Controller
	{
		private readonly IBillService _billService;

		public BillController(IBillService billService)
		{
			_billService = billService;
		}


		public async Task<IActionResult> Index()
		{
			var billDetails = await _billService.GetListBill();
			return View(billDetails);
		}

		[HttpGet("bill-detail/{billId}")]
		public async Task<IActionResult> GetBillDettail(Guid billId)
		{
			var lstBillDetails = await _billService.GetListBillDetail(billId);

			return View(lstBillDetails);
		}
	}
}
