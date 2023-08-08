using AutoMapper;
using ClothesSaleManagement.Application.DTOs.BillDetail;
using ClothesSaleManagement.Application.DTOs.ProductDetail;
using ClothesSaleManagement.Domain.Enums;
using ClothesSaleManagement.WebApp.Models;
using ClothesSaleManagement.WebApp.Services.Bill;
using ClothesSaleManagement.WebApp.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using ClothesSaleManagement.WebApp.Extensions;

namespace ClothesSaleManagement.WebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductService _productService;
		private readonly IBillService _billService;
		private readonly IMapper _mapper;

		public CartController(IProductService productService, IBillService billService, IMapper mapper)
		{
			_productService = productService;
			_billService = billService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var jsonString = HttpContext.Session.GetString(Constant.CartSession);
			if (jsonString == default)
			{
				return View();
			}

			ViewBag.lstCartItems = JsonConvert.DeserializeObject<List<CartItem>>(jsonString);
			foreach (CartItem item in ViewBag.lstCartItems)
			{
				var sizeProduct = await _productService.GetProductDetail(item.ProductDetailId);
				if (sizeProduct != null)
				{
					item.Size = sizeProduct.Size;
				}
				else
				{
					item.Size = Size.S;
				}
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(OrderVM orderVm)
		{
			var jsonString = HttpContext.Session.GetString(Constant.CartSession);
			if (jsonString == default)
				return View();
			if (!ModelState.IsValid)
			{
				ViewBag.lstCartItems = JsonConvert.DeserializeObject<List<CartItem>>(jsonString);
				foreach (CartItem item in ViewBag.lstCartItems)
				{
					var sizeProduct = await _productService.GetProductDetail(item.ProductDetailId);

					item.Size = sizeProduct != null ? sizeProduct.Size : Size.S;
				}
				return View(orderVm);
			}

			var listCartItem = JsonConvert.DeserializeObject<List<CartItem>>(jsonString);

			List<BillDetailCreateDto> billDetailCreateDtos = new List<BillDetailCreateDto>();
			List<ProductDetailDto> productDetailDtos = new List<ProductDetailDto>();

			foreach (var item in listCartItem)
			{
				var billDetailCreate = new BillDetailCreateDto()
				{ Quantity = item.Quantity, Price = item.Price, ProductDetailId = item.ProductDetailId };
				billDetailCreateDtos.Add(billDetailCreate);

				var productDetailDto = new ProductDetailDto()
				{ Id = item.ProductDetailId, Size = item.Size, Stock = item.Quantity, };
				productDetailDtos.Add(productDetailDto);
			}

			var response = await _billService.Create(orderVm);

			if (!response.IsSuscess) return View();

			var billId = response.Data;
			var result = await _billService.CreateBillDetail(billId, billDetailCreateDtos);

			if (!result.IsSuscess) return View();


			var resultResponse = await _productService.UpdateStockAfterPay(productDetailDtos);

			if (resultResponse.IsSuscess)
			{
				TempData["message"] = "Tạo đơn thành công";
				HttpContext.Session.Remove(Constant.CartSession);
				return View();
			}

			TempData["message"] = "Thêm thất bại";
			return View();
		}

		[HttpGet("remove-cart/{id}")]
		public async Task<IActionResult> RemoveCartItem(Guid id)
		{
			var lstCartItem = HttpContext.Session.Get<List<CartItem>>(Constant.CartSession);
			var cartItems = lstCartItem.FirstOrDefault(c => c.ProductDetailId == id);
			if (cartItems != null)
				lstCartItem.Remove(cartItems);
			HttpContext.Session.Set(Constant.CartSession, lstCartItem);

			return RedirectToAction("Index");
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
