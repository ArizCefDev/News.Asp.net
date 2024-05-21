using Business.Abstract;
using Business.Validation;
using DataAccess.MyContext;
using DTO.EntityDTO;
using FluentValidation.Results;
using Helper.Constants;
using Helper.CookieCrypto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News.Asp.net.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategory _category;
        private readonly IPost _post;
        private readonly IUser _user;
        private readonly AppDbContext _dbContext;

		public AdminController(ICategory category, IPost post, IUser user, AppDbContext dbContext)
		{
			_category = category;
			_post = post;
			_user = user;
			_dbContext = dbContext;
		}

		[Authorize(Roles =RoleKeywords.AdminRole)]
        public IActionResult Index()
        {
            var values = _category.GetAll();
            return View(values);
        }

		[Authorize(Roles = RoleKeywords.AdminRole)]
		[HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

		[Authorize(Roles = RoleKeywords.AdminRole)]
		[HttpPost]
        public IActionResult CategoryAdd(CategoryDTO p)
        {
            CategoryValidator c= new CategoryValidator();
            ValidationResult result = c.Validate(p);
            if (result.IsValid)
            {
                _category.Insert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

		[Authorize(Roles = RoleKeywords.AdminRole)]
		public IActionResult CategoryDelete(int id)
        {
            _category.Delete(id);
            return RedirectToAction("Index");
        }

		[Authorize(Roles = RoleKeywords.RedaktorRole)]
		public IActionResult Post()
        {
            var values = _post.GetAllInclude();
            return View(values);
        }

		[Authorize(Roles = RoleKeywords.RedaktorRole)]
		[HttpGet]
        public IActionResult PostAdd()
        {
            ViewBag.ctg = _category.GetAll();
            return View();
        }

		[Authorize(Roles = RoleKeywords.RedaktorRole)]
		[HttpPost]
        public IActionResult PostAdd(PostDTO p)
        {
            ViewBag.ctg = _category.GetAll();

            PostValidator c = new PostValidator();
            ValidationResult result = c.Validate(p);
            if (result.IsValid)
            {
                if (p.Image1!=null)
                {
                    var ex = Path.GetExtension(p.Image1.FileName);
                    var newimg = Guid.NewGuid() + ex;
                    var loc = Path.Combine(Directory.GetCurrentDirectory()
                        , "wwwroot/WebImages/",newimg);
                    var stream = new FileStream(loc, FileMode.Create);
                    p.Image1.CopyTo(stream);
                    p.Image2 = newimg;
                    p.Image1 = null;

                }
                else
                {
                    p.Image2 = null;
                }

                p.FbURL = "https://www.facebook.com/";
                p.WpURL = "https://www.web.whatsapp.com/";
                p.TlgURL = "https://www.telegram.com/";
                p.TwtURL = "https://www.twitter.com/";
                p.PostURL = "https://localhost:44302/Home/Detail/";
                _post.Insert(p);
                return RedirectToAction("Post");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

		[Authorize(Roles = RoleKeywords.RedaktorRole)]
		[HttpGet]
        public IActionResult PostUpdate(int id)
        {
            ViewBag.ctg = _category.GetAll();
            var values = _post.GetByID(id);
            return View(values);
        }

		[Authorize(Roles = RoleKeywords.RedaktorRole)]
		[HttpPost]
        public IActionResult PostUpdate(PostDTO p)
        {
            ViewBag.ctg = _category.GetAll();

            PostValidator c = new PostValidator();
            ValidationResult result = c.Validate(p);
            if (result.IsValid)
            {
                if (p.Image1 != null)
                {
                    var ex = Path.GetExtension(p.Image1.FileName);
                    var newimg = Guid.NewGuid() + ex;
                    var loc = Path.Combine(Directory.GetCurrentDirectory()
                        , "wwwroot/WebImages/", newimg);
                    var stream = new FileStream(loc, FileMode.Create);
                    p.Image1.CopyTo(stream);
                    p.Image2 = newimg;
                    p.Image1 = null;

                }
                else
                {
                    p.Image2 = null;
                }

                p.FbURL = "https://www.facebook.com/";
                p.WpURL = "https://www.web.whatsapp.com/";
                p.TlgURL = "https://www.telegram.com/";
                p.TwtURL = "https://www.twitter.com/";
                p.PostURL = "https://localhost:44302/Home/Detail/";
                _post.Update(p);
                return RedirectToAction("Post");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

		[Authorize(Roles = RoleKeywords.AdminRole)]
		public IActionResult PostDelete(int id)
        {
            _post.Delete(id);
            return RedirectToAction("Post");
        }




		[Authorize(Roles = RoleKeywords.AdminRole)]
		public IActionResult Users()
		{
			var values = _user.GetAll();
			return View(values);
		}

        [Authorize(Roles = RoleKeywords.AdminRole)]
        [HttpGet]
        public IActionResult UsersUpdate(int id)
        {
            ViewBag.rl = _dbContext.Roles.ToList();
            var values = _user.GetByID(id);
            return View(values);
        }

        [Authorize(Roles = RoleKeywords.AdminRole)]
        [HttpPost]
        public IActionResult UsersUpdate(UserDTO p)
        {
            ViewBag.rl = _dbContext.Roles.ToList();
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);
            if (p.Password==null)
            {
                ViewBag.err = "Sifreni daxil edin";
            }
            else
            {
                p.Salt = Crypto.GenerateSalt();
                p.PasswordHash = Crypto.GenerateSHA256Hash(p.Password, p.Salt);
                _user.Update(p);
                return RedirectToAction("Users");
            }

            return View(p);
           
        }
    }
}
