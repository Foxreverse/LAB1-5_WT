﻿

using Microsoft.AspNetCore.Mvc;

namespace Test.UI.Components
{
	public class CartViewComponent: ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            //var cart = HttpContext.Session.Get<Cart>("cart");
            return View(/*cart*/);
        }
    }
}
