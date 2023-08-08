using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
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

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);

		}

		public async Task<IQueryable<T>> GetAllAsync()
		{
			return  _context.Set<T>();
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

		public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
		{
			try
			{
				await _context.Set<T>().AddRangeAsync(entities);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task UpdateRangeAsync(IEnumerable<T> entities)
		{
			try
			{
				_context.UpdateRange(entities);
			}
			catch (Exception e)
			{
				var eMessage = e.Message;
			}
		}
	}
}
