using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Frontpage()
        {
            DBOrder order = new DBOrder();
            List<Product> topFive  = order.getMostSold();
            return View(topFive);

        }


    }
}