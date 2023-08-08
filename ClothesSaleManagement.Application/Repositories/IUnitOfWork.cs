using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IUnitOfWork:IDisposable
	{
		IBillRepository BillRepository { get; }
		IBillDetailRepository BillDetailRepository { get; }
		ICartRepository CartRepository { get; }
		ICartDetailRepository CartDetailRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		IProductRepository ProductRepository { get; }
		IProductDetailRepository ProductDetailRepository { get; }

		Task Save();
	}
}
