using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Application.Repositories;
using ClothesSaleManagement.Domain;
using ClothesSaleManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class ProductDetailRepository : GenericRepository<ProductDetail>, IProductDetailRepository
	{
		private readonly ClothesSaleManagementContext _context;

		public ProductDetailRepository(ClothesSaleManagementContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductDetail>> GetProductDetail(Guid productId)
		{
			return await _context.ProductDetails.Where(c => c.ProductId == productId).ToListAsync();
		}

		public async Task<bool> ExistsSize(Guid productId, Size size)
		{
			return await _context.ProductDetails.AnyAsync(c => c.ProductId == productId && c.Size == size);
		}
	}
}
