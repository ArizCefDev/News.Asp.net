using Business.Abstract;
using DataAccess.MyContext;
using Microsoft.AspNetCore.Mvc;
using News.Asp.net.Models;
using System.Diagnostics;

namespace News.Asp.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _post;
        private readonly AppDbContext _dbContext;

		public HomeController(IPost post, AppDbContext dbContext)
		{
			_post = post;
			_dbContext = dbContext;
		}

		public IActionResult Index()
        {
            var values = _post.GetAll();
            return View(values.OrderByDescending(row=>row.Id).Take(4));
        }

		public IActionResult Page()
		{
			var values=_post.GetAll();
			return View(values);
		}


	}
}