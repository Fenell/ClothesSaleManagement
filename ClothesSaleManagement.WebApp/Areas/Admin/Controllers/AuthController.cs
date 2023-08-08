using ClothesSaleManagement.Application.Models.Identity;
using ClothesSaleManagement.Application.Repositories.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginRequest request)
		{
			if (!ModelState.IsValid)
				return View(request);

			var isSuccess = await _authService.Login(request);
			if (isSuccess)
				return RedirectToAction("Index", "Admin");
			ViewBag.message = "Sai tài khoản hoặc mật khẩu";

			return View(request);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _authService.Logout();
			return RedirectToAction("Index");
		}

		
	}
}
