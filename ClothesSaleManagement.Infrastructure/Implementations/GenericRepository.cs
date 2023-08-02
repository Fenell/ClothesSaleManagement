using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class GenericRepository<T>: IGenericRepository<T> where T : class
	{
		private readonly ClothesSaleManagementContext _context;

		public GenericRepository(ClothesSaleManagementContext context)
		{
			_context = context;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);

		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(dynamic id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<bool> Exists(dynamic id)
		{
			var entity = await GetByIdAsync(id);
			return entity != null;
		}
	}
}
