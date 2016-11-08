using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Models;
using System.Web.WebPages.Html;
using System.Data.Entity;

namespace Nettbutikk
{

    

    public class DBProduct
    {
        public List<Product> getAll(int? id, String sc, int? sort)
        {
           
            var db = new DatabaseContext();
            List<Product> allProducts = new List<Product>();
            var products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategoriesId == id).OrderBy(p => p.Name).ToList();
            switch (sort)
            {
                case 1:
                    products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategoriesId == id).OrderBy(p => p.Name).ToList();
                    break;
                case 2:
                    products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategoriesId == id).OrderBy(p => p.Price).ToList();
                    break;
                case 3:
                    products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategoriesId == id).OrderByDescending(p => p.Price).ToList();
                    break;
            }
           
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
                    pricePerLitre = pricePerLitre(p.Price, p.Volum),
                    category = p.SubCategories.Categories.Name,
                    categoryid = p.SubCategories.Categories.Id,
                    subCategory = p.SubCategories.Name,
                    subCategoryid = p.SubCategories.Id,
                    country = p.Countries.Name

                };
                allProducts.Add(product);
            }

            return allProducts;
        }
        
        public List<Product> getAll(int? id, int? sort)
        {
            var db = new DatabaseContext();
            List<Product> allProducts = new List<Product>();
            if (id.HasValue)
            {
                var products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).OrderBy(p=>p.Name).ToList();
                switch (sort)
                {
                    case 1:
                        products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).OrderBy(p => p.Name).ToList();
                        break;
                    case 2:
                        products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).OrderBy(p => p.Price).ToList();
                        break;
                    case 3:
                        products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).OrderByDescending(p => p.Price).ToList();
                        break;
                }

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
                        pricePerLitre = pricePerLitre(p.Price, p.Volum),
                        category = p.SubCategories.Categories.Name,
                        categoryid = p.SubCategories.Categories.Id,
                        subCategory = p.SubCategories.Name,
                        subCategoryid = p.SubCategories.Id,
                        country = p.Countries.Name

                    };
                    allProducts.Add(product);
                }
            }
            else
            {
                var products = db.Products.Include(p => p.SubCategories.Categories).OrderBy(p => p.Name).ToList();

                switch (sort)
                {
                    case 1:
                        products = db.Products.Include(p => p.SubCategories.Categories).OrderBy(p => p.Name).ToList();
                        break;
                    case 2:
                        products = db.Products.Include(p => p.SubCategories.Categories).OrderBy(p=>p.Price).ToList();  
                        break;
                    case 3:
                        db.Products.Include(p => p.SubCategories.Categories).OrderByDescending(p => p.Price).ToList(); 
                       break;
                }

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
                        pricePerLitre = pricePerLitre(p.Price, p.Volum),
                        category = p.SubCategories.Categories.Name,
                        categoryid = p.SubCategories.Categories.Id,
                        subCategory = p.SubCategories.Name,
                        subCategoryid = p.SubCategories.Id,
                        country = p.Countries.Name
                    };
                    allProducts.Add(product);
                }
            }

            return allProducts;
        }
        public Product get(int id)
        {
            var db = new DatabaseContext();
            Products products = db.Products.Include(p => p.SubCategories.Categories).Where(p=> p.Id == id).FirstOrDefault<Products>();
            return new Product()
            {
                itemnumber = products.Id,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                volum = products.Volum,
                pricePerLitre = pricePerLitre(products.Price, products.Volum),
                producer = products.Producers.Name,
                category = products.SubCategories.Categories.Name,
                categoryid = products.SubCategories.Categories.Id,
                subCategory = products.SubCategories.Name,
                subCategoryid = products.SubCategories.Id,
                country = products.Countries.Name
            };
        }

        private double pricePerLitre(int price, double volume)
        {
            return Math.Round(((price / volume)*100),0);
        }

        public List<Product> getResult(string searchString)
        {
            var db = new DatabaseContext();
            List<Product> foundProducts = new List<Product>();
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
                    pricePerLitre = pricePerLitre(p.Price, p.Volum),
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

        public List<string> getAutoComplete(string term)
        {
            DatabaseContext db = new DatabaseContext();
            List<string> foundProducts;
            foundProducts = db.Products.Where(x => x.Name.StartsWith(term))
                                               .Select(y => y.Name).ToList();
            return foundProducts;
        }
    }
}