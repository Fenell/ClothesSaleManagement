using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Domain;
using Microsoft.AspNetCore.Http;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IProductRepository:IGenericRepository<Product>
	{
		Task<List<Product>> GetAllProductWtihCategory();
		Task<Product?> GetAllProductWtihCategory(Guid id);

		Task<string> UploadFileImg(IFormFile file);
	}
}
