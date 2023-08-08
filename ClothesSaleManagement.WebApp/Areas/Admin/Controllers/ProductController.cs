using AutoMapper;
using ClothesSaleManagement.WebApp.Models;
using ClothesSaleManagement.WebApp.Services.Category;
using ClothesSaleManagement.WebApp.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesSaleManagement.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
		{
			_productService = productService;
			_categoryService = categoryService;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			var listProducts = await _productService.GetAllProduct();
			return View(listProducts);
		}

		[HttpGet("product-detail/{id}")]
		public async Task<IActionResult> Update(Guid id)
		{
			var productVm = await _productService.GetProduct(id);
			var category = await _categoryService.GetAll();

			ViewBag.lstProductDetails = productVm.ProductDetailDtos.ToList();
			productVm.SelectListCategory = new SelectList(category, "Id", "Name", productVm.CategoryId);
			var productUpdate = _mapper.Map<ProductUpdateVM>(productVm);

			return View(productUpdate);
		}

		[HttpPost("product-detail/{id}")]
		public async Task<IActionResult> Update(Guid id, ProductUpdateVM productUpdate)
		{
			if (!ModelState.IsValid)
				return View(productUpdate);

			var response = await _productService.UpdateProduct(id, productUpdate);

			if (response.IsSuscess)
			{
				return RedirectToAction("Index");
			}

			return View(productUpdate);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var categories = await _categoryService.GetAll();
			var categorySelectList = new SelectList(categories, "Id", "Name");
			var produtCreateVm = new ProductCreateVM() { SelectListCategory = categorySelectList };

			return View(produtCreateVm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
		{
			var categories = await _categoryService.GetAll();
			productCreateVM.SelectListCategory = new SelectList(categories, "Id", "Name");
			if (!ModelState.IsValid)
				return View(productCreateVM);

			var response = await _productService.CreateProduct(productCreateVM);

			return RedirectToAction("Index");
		}

		[HttpGet("delete-product/{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var response= await _productService.DeleteProduct(id);
			if(response.IsSuscess)
			 return RedirectToAction("Index");

            return Content("Delete fail");
        }

		[HttpGet("update-stock/{id}")]
		public async Task<IActionResult> UpdateStock(Guid id)
		{
			var productDetail = await _productService.GetProductDetail(id);
			return View(productDetail);
		}

		[HttpPost("update-stock/{id}")]
		public async Task<IActionResult> UpdateStock(Guid id, ProductDetailVm productDetailVm)
		{
			if (!ModelState.IsValid)
				return View(productDetailVm);

			await _productService.UpdateStockProduct(id, productDetailVm);

			return RedirectToAction("Update", new{id = productDetailVm.ProductId});
		}

		[HttpGet("add-size-product/{productId}")]
		public async Task<IActionResult> CreateSizeProduct(Guid productId)
		{
			return View();
		}

		[HttpPost("add-size-product/{productId}")]
		public async Task<IActionResult> CreateSizeProduct(Guid productId, ProductDetailVm productDetailVm)
        {
			if (!ModelState.IsValid)
				return View(productDetailVm);

            var response = await _productService.CreateSizeProduct(productId,productDetailVm);

            if (response.IsSuscess)
                return RedirectToAction("Update", new { id = productId });

            return View(productDetailVm);
        }
	}
}
