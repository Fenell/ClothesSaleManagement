using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Domain;
using ClothesSaleManagement.Domain.Enums;

namespace ClothesSaleManagement.Application.Repositories
{
	public interface IProductDetailRepository:IGenericRepository<ProductDetail>
	{
		Task<IEnumerable<ProductDetail>> GetProductDetail(Guid productId);
		Task<bool> ExistsSize(Guid productId, Size size);

		//	Task<ProductDetailDto> CreateProductDetail(Guid productId, Product productDetail);

	}
}
