using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using News.Asp.net.Models;
using System.Diagnostics;

namespace News.Asp.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _post;

		public HomeController(IPost post)
		{
			_post = post;
		}

		public IActionResult Index()
        {
            var values = _post.GetAll();
            return View(values.OrderByDescending(row=>row.Id).Take(4));
        }

       
    }
}