using Microsoft.AspNetCore.Mvc;

namespace News.Asp.net.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
