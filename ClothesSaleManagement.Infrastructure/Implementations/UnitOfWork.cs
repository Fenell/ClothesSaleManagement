using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.Repositories;

namespace ClothesSaleManagement.Infrastructure.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ClothesSaleManagementContext _context;

		public UnitOfWork(ClothesSaleManagementContext context)
		{
			_context = context;
			BillRepository = new BillRepository(_context);
			BillDetailRepository = new BillDetailRepository(_context);
			CartRepository = new CartRepository(_context);
			CartDetailRepository = new CartDetailRepository(_context);
			CategoryRepository = new CategoryRepository(_context);
			ProductRepository = new ProductRepository(_context);
			ProductDetailRepository = new ProductDetailRepository(_context);
		}

		public IBillRepository BillRepository { get; }
		public IBillDetailRepository BillDetailRepository { get; }
		public ICartRepository CartRepository { get; }
		public ICartDetailRepository CartDetailRepository { get; }
		public ICategoryRepository CategoryRepository { get; }
		public IProductRepository ProductRepository { get; }
		public IProductDetailRepository ProductDetailRepository { get; }

		public async Task Save()
		{
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				var exMessage = ex.Message;
			}
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
