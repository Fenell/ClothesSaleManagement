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
			SizeRepository = new SizeRepository(_context);
		}

		public IBillRepository BillRepository { get; }
		public IBillDetailRepository BillDetailRepository { get; }
		public ICartRepository CartRepository { get; }
		public ICartDetailRepository CartDetailRepository { get; }
		public ICategoryRepository CategoryRepository { get; }
		public IProductRepository ProductRepository { get; }
		public ISizeRepository SizeRepository { get; }

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
