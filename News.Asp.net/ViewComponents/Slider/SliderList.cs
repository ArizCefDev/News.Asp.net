using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace News.Asp.net.ViewComponents.Slider
{
    public class SliderList : ViewComponent
    {
        private readonly IPost _post;

        public SliderList(IPost post)
        {
            _post = post;
        }

        public IViewComponentResult Invoke()
        {
            var values = _post.GetAll();
            return View(values.OrderByDescending(row => row.Id).Take(5));
        }
    }
}
