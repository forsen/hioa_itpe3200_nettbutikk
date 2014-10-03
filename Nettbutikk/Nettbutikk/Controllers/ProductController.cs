﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ListProducts(int? id)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;

            if(id.HasValue)
                listOfProducts = db.getAll(id);
            else
                listOfProducts = db.getAll(id);
    
            return View(listOfProducts);
        }

        public ActionResult ListSub(int? id)
        {
            var db = new DBProduct();
            List<Product> listSub;

            if (id.HasValue)
                listSub = db.getAll(id);
            else
                listSub = db.getAll(id);

            return View(listSub);
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

        public double pricePerLitre(int id)
        {
            var db = new DBProduct();
            double pricePerLitre = ((db.get(id).price) / (db.get(id).volum) * 100);
            return pricePerLitre;
        }

        public ActionResult viewProduct(int id)
        {
            var db = new DBProduct();
            Product p = db.get(id);
            p.pricePerLitre = pricePerLitre(id);
            return View(p);
        }

        public JsonResult getResults(string term)
        {
            DatabaseContext db = new DatabaseContext();
            List<string> foundProducts;
            foundProducts = db.Products.Where(x=>x.Name.StartsWith(term))
                                               .Select(y => y.Name).ToList();

            return Json(foundProducts, JsonRequestBehavior.AllowGet);
        }
    }
}