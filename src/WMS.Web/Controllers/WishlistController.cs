using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Web.Models;

namespace WMS.Web.Controllers
{
    public class WishlistController : Controller
    {
        public ActionResult AddToWishlist(Product product)
        {
            return View();
        }

    }
}
