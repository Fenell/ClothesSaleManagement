using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class BillDetailRepository:GenericRepository<BillDetail>, IBillDetailRepository
	{
		private readonly ClothesSaleManagementContext _context;

		public BillDetailRepository(ClothesSaleManagementContext context): base(context)
		{
			_context = context;
		}

		public async Task<List<BillDetail>> GetListBillDetail(Guid billId)
		{
			var listBllDetails =  await _context.BillDetails.Where(c=>c.BillId == billId).Include(c=>c.ProductDetail).Include(c=>c.Bil).ToListAsync();

			return listBllDetails;
		}

		public async Task<List<BillDetail>> AddRangeBillDetail(Guid billId, List<BillDetail> lstBillDetail)
		{
			foreach (var item in lstBillDetail)
			{
				item.BillId = billId;
			}

			await _context.BillDetails.AddRangeAsync(lstBillDetail);

			return lstBillDetail;
		}

	
	}
}
