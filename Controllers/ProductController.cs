using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;
using System.Diagnostics;

namespace Nettbutikk.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult ListProducts(int? id, string sc, int? sort)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
            if(sc != null && sc.Equals("yes"))
              {
                listOfProducts = db.getAll(id,sc,sort);
              }
            else
             {
                
                listOfProducts = db.getAll(id,sort);
             }
            
            return View(listOfProducts);
        }


        public ActionResult Search(string searchString)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                listOfProducts = db.getResult(searchString);
                return View(listOfProducts);
            }
            else
            {
                listOfProducts = db.getResult("Tomt");
                return View(listOfProducts);
            }
        }

        public ActionResult viewProduct(int id)
        {
            var db = new DBProduct();
            Product p = db.get(id);
            return View(p);
        }

        public JsonResult getResults(string term)
        {
            var db = new DBProduct();
            List<string> foundProducts = db.getAutoComplete(term);

            return Json(foundProducts, JsonRequestBehavior.AllowGet);
        }
    }
}