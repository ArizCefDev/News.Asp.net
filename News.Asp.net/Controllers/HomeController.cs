using Business.Abstract;
using DataAccess.MyContext;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;
using News.Asp.net.Models;
using System.Diagnostics;

namespace News.Asp.net.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPost _post;
		private readonly IComment _comment;
		private readonly AppDbContext _dbContext;

		public HomeController(IPost post, IComment comment, AppDbContext dbContext)
		{
			_post = post;
			_comment = comment;
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var values = _post.GetAll();
			return View(values.OrderByDescending(row => row.Id));
		}

		public IActionResult All(string search)
		{
			var values = from a in _post.GetAll() select a;
			if (!string.IsNullOrEmpty(search))
			{
				values = values.Where(x => x.Title.ToLower().Contains(search.ToLower()));
			}
			ViewBag.i = search;
			ViewBag.c = values.Count();
			return View(values.OrderByDescending(row => row.Id));
		}

		public IActionResult Page(int id)
		{
			ViewBag.cat = _dbContext.Categories.Where(x => x.Id == id).Select(y => y.Name).First();

			var values = _post.GetCategoryPostId(id);
			return View(values);
		}


		public IActionResult Detail(int id)
		{
			CommentDTO p = new CommentDTO();
			ViewBag.count = _comment.GetAll().Where(x => x.PostID == id).Count();
			ViewBag.cat = _dbContext.Categories.ToList().Skip(6).Take(3);
			ViewBag.allcat = _dbContext.Categories.ToList();
			ViewBag.postID = id;

			var values = _post.GetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult CommentAdd(CommentDTO p)
		{
			if (p.UserName == null)
			{
				ViewBag.error = "error";
			}
			else
			{
				p.Time = DateTime.Now;
				p.ImageURL = "/img/comment.jpg";
				_comment.Insert(p);
				int x = p.PostID;
				return RedirectToAction("Detail", new { id = x });
			}
			return View(p);

		}


	}
}