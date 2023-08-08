using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class BillRepository:GenericRepository<Bill>, IBillRepository
	{
		private readonly ClothesSaleManagementContext _context;

		public BillRepository(ClothesSaleManagementContext context): base(context)
		{
			_context = context;
		}


		public async Task<Bill> GetBillAsync(Guid id)
		{
			var bill = await _context.Bills.Include(c => c.BillDetails).FirstOrDefaultAsync(c => c.Id == id);

			return bill;
		}

		public async Task<List<Bill>> GetListBillAsync()
		{
			return await _context.Bills.Include(c=>c.BillDetails).ToListAsync();
		}
	}
}
