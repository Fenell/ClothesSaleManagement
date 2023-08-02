using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class BillRepository:GenericRepository<Bill>, IBillRepository
	{
		private readonly ClothesSaleManagementContext _context;

		public BillRepository(ClothesSaleManagementContext context): base(context)
		{
			_context = context;
		}
	}
}
