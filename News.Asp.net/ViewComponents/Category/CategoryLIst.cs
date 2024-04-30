using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace News.Asp.net.ViewComponents.Category
{
	public class CategoryLIst:ViewComponent
	{
		private readonly ICategory _category;

		public CategoryLIst(ICategory category)
		{
			_category = category;
		}

		public IViewComponentResult Invoke()
		{
			var values = _category.GetAll();
			return View(values);
		}
	}
}
