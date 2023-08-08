using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.Product;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ClothesSaleManagementContext _context;

		public ProductRepository(ClothesSaleManagementContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetAllProductWtihCategory()
		{
			var listProducts = await _context.Products.AsNoTracking().Include(c => c.Category)
				.ToListAsync();

			return listProducts;
		}

		public async Task<Product?> GetAllProductWtihCategory(Guid id)
		{
			var product = await _context.Products.AsNoTracking().Include(c => c.Category)
				.FirstOrDefaultAsync(a => a.Id == id);

			return product;
		}

		public async Task<string> UploadFileImg(IFormFile file)
		{
			if (file.Length >= 0)
			{
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

				using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
				{
					await file.CopyToAsync(fileStream);
				}

				return "/images/" + file.FileName;
			}

			return "";
		}
	}
}
