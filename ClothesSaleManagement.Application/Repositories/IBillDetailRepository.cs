using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IBillDetailRepository:IGenericRepository<BillDetail>
	{
		Task<List<BillDetail>> GetListBillDetail(Guid billId);

		Task<List<BillDetail>> AddRangeBillDetail(Guid billId, List<BillDetail> lstBillDetail);
	}
}
