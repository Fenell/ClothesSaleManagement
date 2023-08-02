using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IGenericRepository<T> where T:class
	{
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(dynamic id);
		Task<bool> Exists(dynamic id);

	}
}
