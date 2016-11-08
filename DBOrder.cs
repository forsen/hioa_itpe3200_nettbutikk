using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nettbutikk
{
    public class DBOrder
    {
        public int checkout(ShoppingCart cart)
        {
            var db = new DatabaseContext();

            var newOrder = new Orders()
            {
                OrderDate = DateTime.Now, 
                CustomersId = cart.userID
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            

            foreach (var item in cart.shoppingCartItems)
            {
                var newItem = new OrderLines()
                {
                    ProductsId = item.product.itemnumber,
                    OrdersId = newOrder.Id,
                    Quantity = item.quantity
                };
                db.OrderLines.Add(newItem);
            }
            db.SaveChanges();

            return newOrder.Id;
        }

        public List<Order> getOrders(int id)
        {
            var db = new DatabaseContext();
            var order = db.Orders.Where(o => o.CustomersId == id).ToList();
            Debug.WriteLine("Antall i denne lista daaa?");
            Debug.WriteLine(order.Count);
            List<Order> list = new List<Order>();
            foreach (var item in order){
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                });
            }
            return list; 
        }
        public List<OrderLine> getOrder(int id)
        {
            Debug.WriteLine("OrdreID: " + id);
            var db = new DatabaseContext();
            var lines = db.OrderLines.Include(p => p.Products).Where(o => o.OrdersId == id).ToList();
            Debug.WriteLine("Antall ordrelinjer fra db");
            Debug.WriteLine(lines.Count);
            List<OrderLine> list = new List<OrderLine>();
            foreach (var item in lines)
            {
                var itemProduct = new Product()
                {
                    itemnumber = item.Products.Id,
                    name = item.Products.Name,
                    price = item.Products.Price,
                    description = item.Products.Description
                };
                list.Add(new OrderLine()
                {
                    product = itemProduct,
                    quantity = item.Quantity
                });
            }
            return list;
        }

        public List<Product> getMostSold()
        {
            var db = new DatabaseContext();
            List<int> topOrders = db.OrderLines
                                    .GroupBy(p => p.ProductsId)
                                    .OrderByDescending(gp => gp.Count())
                                    .Take(4)
                                    .Select(g => g.Key).ToList();
            List<Products> products = new List<Products>(); 
            
            foreach (var i in topOrders)
            {
                products.Add(db.Products.Where(p => p.Id == i).First());
            }
            List<Product> prod = new List<Product>();
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
                    subCategory = p.SubCategories.Name,
                    subCategoryid = p.SubCategories.Id,
                    country = p.Countries.Name
                };
                prod.Add(product);
            }

            
            return prod;
        }
            
    }
}