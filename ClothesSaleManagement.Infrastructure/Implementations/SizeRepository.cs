using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class SizeRepository:GenericRepository<Size>, ISizeRepository
	{
		public SizeRepository(ClothesSaleManagementContext context) : base(context)
		{
		}
	}
}
