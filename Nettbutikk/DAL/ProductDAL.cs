﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Model;
using System.Data.Entity;

namespace Nettbutikk.DAL
{

    public class ProductDAL : DAL.IProductDAL
    {
        public List<Category> getAllCategories()
        {
            var db = new DatabaseContext();
            var categories = db.Categories.ToList();
            var list = new List<Category>();
            foreach (var item in categories)
            {
                list.Add(new Category()
                {
                    ID = item.Id,
                    name = item.Name
                });
            }
            return list; 
        }
        public List<Product> getAll(int? id, String sc, int? sort)
        {
            return new List<Product>();
        }

        public List<Product> getAll(int? id)
        {
            var db = new DatabaseContext();
            List<Products> products; 
            if(id != null)
                products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).ToList();
            else
                products = db.Products.Include(p => p.SubCategories.Categories).ToList();
            var list = new List<Product>();
            foreach (var item in products)
            {
                list.Add(new Product()
                {
                    itemnumber = item.Id,
                    name = item.Name,
                    description = item.Description,
                    price = item.Price,
                    volum = item.Volum,
                    producer = item.Producers.Name,
                    country = item.Countries.Name
                });
            }
            return list;
        }
 
        public Product get(int id)
        {
            return null;
        }

        public List<Product> getResult(int? id, string searchString)
        {
            var db = new DatabaseContext();
            var foundProducts = new List<Product>();
            var products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())
                            || p.Description.ToUpper().Contains(searchString.ToUpper())).ToList();
            foreach (var p in products)
            {
                var product = new Product()
                {
                    itemnumber = p.Id,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    volum = p.Volum,
                    producer = p.Producers.Name,
                    category = p.SubCategories.Categories.Name,
                    categoryid = p.SubCategories.Categories.Id,
                    subCategory = p.SubCategories.Name,
                    subCategoryid = p.SubCategories.Id,
                    country = p.Countries.Name
                };
                foundProducts.Add(product);
            }
            return foundProducts;
        }

        public Product findProduct(int id)
        {
            var db = new DatabaseContext();
            Products products = db.Products.Include(p => p.SubCategories.Categories)
                .Where(p => p.Id == id).FirstOrDefault<Products>();
            return new Product()
            {
                itemnumber = products.Id,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                volum = products.Volum,
                producer = products.Producers.Name,
                category = products.SubCategories.Categories.Name,
                categoryid = products.SubCategories.Categories.Id,
                subCategory = products.SubCategories.Name,
                subCategoryid = products.SubCategories.Id,
                country = products.Countries.Name
            };
        }

        public List<string> getAutoComplete(string term)
        {
            var db = new DatabaseContext();
            List<string> searchList = new List<string>();
            searchList = db.Products.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();
            return searchList;
        }


        // TODO: Denne skal testes på web når siden er oppe!

        public bool updateProduct(int id, Product update)
        {
            return false;
        }

            /*
            var db = new DatabaseContext();
            try
            {
                Products prod = db.Products.FirstOrDefault(u => u.Id == id);

                prod.Name = update.name;
                prod.Description = update.description;
                prod.LongDescription = update.longDescription;
                prod.Price = update.price;
                prod.Volum = update.volum;

                    
                // TODO: Trenger mer i denne metoden
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
             */
    }
}

