using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult viewShoppingCart()
        {
            ShoppingCart cart = getCart();
            if (cart != null)
                return View(cart);
            else
                return RedirectToAction("Frontpage", "Main");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addToCart(int quantity, int itemnumber)
        {
            var db = new DBProduct();
            Product p = db.get(itemnumber);
            ShoppingCart cart = getCart();
            if (cart == null)
                return Json(false);  
            ShoppingCartItem item = new ShoppingCartItem(p, quantity);
            List<ShoppingCartItem> list = cart.shoppingCartItems;
            cart.sum += p.price * quantity;
            list.Add(item);

            return RedirectToAction("viewShoppingCart");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult updateCart(int id, int quantity)
        {
            Customer cust = (Customer)Session["LoggedInUser"];
            ShoppingCart cart = cust.shoppingcart;
            cart.sum -= cart.shoppingCartItems[id].price;
            cart.shoppingCartItems[id].price = cart.shoppingCartItems[id].product.price * Math.Abs(quantity);
            cart.shoppingCartItems[id].quantity = Math.Abs(quantity);

            cart.sum += cart.shoppingCartItems[id].price;
            Session["LoggedInUser"] = cust;
            return RedirectToAction("viewShoppingCart");
        }

        public ActionResult removeItem(int id)
        {
            Customer cust = (Customer)Session["LoggedInUser"];
            ShoppingCart cart = cust.shoppingcart;
            cart.sum -= cart.shoppingCartItems[id].price; 
            cart.shoppingCartItems.RemoveAt(id);
            Session["LoggedInUser"] = cust;
            return RedirectToAction("viewShoppingCart");
        }
 
        private ShoppingCart getCart()
        {
            if (Session["loggedInUser"] != null)
            {
                Customer c = (Customer)Session["loggedInUser"];
                ShoppingCart cart = c.shoppingcart;
                return cart;
            }
            return null;
        }


        public ActionResult checkout(Order order)
        {
            RedirectToAction("viewShoppingCart");
            if (order.id != 0)
            {
                return View(showOrder(order));
            }
                
            
            ViewBag.Empty = false; 
            ShoppingCart cart = getCart();
            if (cart == null)
            {
                ViewBag.Empty = true;
                return View();
            }

            var orderDB = new DBOrder();
            var OrderId = orderDB.checkout(cart);
            
            var returnCustomer= (Customer) Session["LoggedInUser"];
            returnCustomer.shoppingcart = new ShoppingCart(returnCustomer.id);
            Session["LoggedInUser"] = returnCustomer; 

            return View(new BillingDocument()
            {
                customer = returnCustomer,
                shoppingcart = cart,
                order = new Order()
                {
                    id = OrderId,
                    customerid = returnCustomer.id,
                    orderdate = DateTime.Now
                },
                sum = cart.sum, 
                exmva = cart.sum * 0.8,
                mva = cart.sum * 0.2
            }); 

        }

        private BillingDocument showOrder(Order id)
        {
  
            var orderDB = new DBOrder();
            List<OrderLine> list = orderDB.getOrder(id.id);
            List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();
            var cartSum = 0;
            foreach(var item in list){
                cartItems.Add(new ShoppingCartItem(item.product, item.quantity));
                cartSum += item.product.price * item.quantity;
            };
            var cart = new ShoppingCart(id.customerid)
            {
                shoppingCartItems = cartItems,
                sum = cartSum
            };
            var billingDoc = new BillingDocument(){
                order = id,
                customer = (Customer) Session["LoggedInUser"],
                shoppingcart = cart,
                sum = cart.sum, 
                exmva = cart.sum * 0.8,
                mva = cart.sum * 0.2

            };
            return billingDoc;
        }
    }
}