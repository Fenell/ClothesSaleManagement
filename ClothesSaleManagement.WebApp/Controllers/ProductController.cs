using Microsoft.AspNetCore.Mvc;

namespace ClothesSaleManagement.WebApp.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
