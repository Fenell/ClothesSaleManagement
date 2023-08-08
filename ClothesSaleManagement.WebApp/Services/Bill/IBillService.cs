using ClothesSaleManagement.Application.DTOs.Bill;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.WebApp.Models;
using Microsoft.Build.ObjectModelRemoting;

namespace ClothesSaleManagement.WebApp.Services.Bill
{
	public interface IBillService
	{
		Task<List<BillDto>> GetListBill();

		Task<List<BillDetailDto>> GetListBillDetail(Guid billId);

		Task<Response<Guid>> Create (OrderVM  orderVm);

		Task<Response<bool>> CreateBillDetail(Guid billId, List<BillDetailCreateDto> billDetailCreateDtos);
	}
}
