using ClothesSaleManagement.WebApp.Models;
using ClothesSaleManagement.WebApp.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryVms = await _categoryService.GetAll();

            return View(categoryVms);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }

            await _categoryService.Create(categoryVm);

            return RedirectToAction("Index");
        }

        [HttpGet("category-update/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            var response = await _categoryService.GetById(id);
            if (response.IsSuscess)
            {
                return View(response.Data);
            }

            return View();
        }

        [HttpPost("category-update/{id}")]
        public async Task<IActionResult> Update(Guid id, CategoryVM categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }

            await _categoryService.Update(id, categoryVm);

            return RedirectToAction("Index");
        }
    }
}
