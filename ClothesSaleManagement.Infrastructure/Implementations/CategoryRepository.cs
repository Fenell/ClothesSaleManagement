using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(ClothesSaleManagementContext context) : base(context)
		{
		}
	}
}
