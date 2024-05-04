using Business.Abstract;
using DataAccess.MyContext;
using Microsoft.AspNetCore.Mvc;

namespace News.Asp.net.ViewComponents.News
{
    public class NewsList : ViewComponent
    {
        private readonly IPost _post;
        private readonly AppDbContext _dbContext;

        public NewsList(IPost post, AppDbContext dbContext)
        {
            _post = post;
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.idman = _dbContext.Posts.Where(x=>x.Category.Name=="Idman").Take(6).ToList();
            ViewBag.siyaset = _dbContext.Posts.Where(x=>x.Category.Name=="Siyasət").Take(6).ToList();

            var values = _post.GetAll();
            return View(values.OrderByDescending(row => row.Id));
        }
    }
}
