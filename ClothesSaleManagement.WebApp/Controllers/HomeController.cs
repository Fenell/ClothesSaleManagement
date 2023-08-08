using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClothesSaleManagement.WebApp.Extensions;
using ClothesSaleManagement.WebApp.Models;
using ClothesSaleManagement.WebApp.Services.Product;
using Newtonsoft.Json;

namespace ClothesSaleManagement.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var listProducts = await _productService.GetAllProduct();

			return View(listProducts);
		}

		[HttpGet("products/{id}")]
		public async Task<IActionResult> ProductDetail(Guid id)
		{
			var product = await _productService.GetProduct(id);

			return View(product);
		}

		[HttpPost("add-to-cart/{id}")]
		public async Task<IActionResult> AddToCart(Guid id, ProductVM productVm)
		{
			var listCartItem = GetListCartItems();

			var cartItem = listCartItem.FirstOrDefault(c => c.ProductDetailId == productVm.ProductDetailId);
			if (cartItem != null)
			{
				cartItem.Quantity += productVm.Quantity;
			}
			else
			{
				cartItem = new CartItem()
				{
					ProductId = productVm.Id,
					ProductDetailId = productVm.ProductDetailId,
					Name = productVm.Name,
					ImgUrl = productVm.ImageUrl,
					Quantity = productVm.Quantity,
					Price = productVm.Price
				};
				listCartItem.Add(cartItem);
			}

			HttpContext.Session.SetString(Constant.CartSession, JsonConvert.SerializeObject(listCartItem));

			return RedirectToAction("Index", "Cart");
		}

		public async Task<IActionResult> GetQuantityProduct(Guid id)
		{
			var productDetail = await _productService.GetProductDetail(id);

			return Json(new { stock = productDetail.Stock.ToString() });
		}

		private List<CartItem>? GetListCartItems()
		{
			var jsonString = HttpContext.Session.GetString(Constant.CartSession);
			if (jsonString != null)
				return JsonConvert.DeserializeObject<List<CartItem>>(jsonString);

			return new List<CartItem>();
		}

	}
}