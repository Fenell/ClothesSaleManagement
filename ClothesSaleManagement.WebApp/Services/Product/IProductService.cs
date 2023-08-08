using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.WebApp.Models;

namespace ClothesSaleManagement.WebApp.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllProduct();
        Task<ProductVM> GetProduct(Guid id);
        Task<Response<ProductCreateVM>> CreateProduct(ProductCreateVM product);
        Task<Response<bool>> DeleteProduct(Guid id);
        Task<Response<Guid>> UpdateProduct(Guid id, ProductUpdateVM product);
        Task<Response<Guid>> UpdateStockProduct(Guid productDetailId, ProductDetailVm productDetailVm);
        Task<ProductDetailVm> GetProductDetail(Guid id);
        Task<Response<Guid>> CreateSizeProduct(Guid productId, ProductDetailVm productDetailVm);

        Task<Response<bool>> UpdateStockAfterPay(List<ProductDetailDto> detailDtos);

    }

}
