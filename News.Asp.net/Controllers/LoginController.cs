using Business.Concrete;
using DTO.EntityDTO;
using Helper.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Business.Abstract;
using DataAccess.MyContext;

namespace News.Asp.net.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUser _userService;
        private readonly AppDbContext _dbContext;

        public LoginController(IUser userService, AppDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO p)
        {
            try
            {
                _userService.Insert(p);

                ViewBag.Success = "Hesabınız yarandı.";
                return View(p);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO p)
        {
            try
            {
                var user = _userService.Login(p);

                Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Login");
        }

        //Cookie
        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.RoleName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
