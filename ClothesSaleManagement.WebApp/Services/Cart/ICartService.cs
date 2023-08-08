using ClothesSaleManagement.WebApp.Models;

namespace ClothesSaleManagement.WebApp.Services.Cart
{
	public interface ICartService
	{
		Task AddToCart(ProductVM  product);
	}
}
