﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nettbutikk.DAL
{
    public class OrderDAL : DAL.IOrderDAL
    {
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            var db = new DatabaseContext();
            var lines = db.OrderLines.Include(p => p.Products).Include(c => c.Orders.Customers).Where(ol =>ol.OrdersId  == id).ToList();
            List<OrderLine> list = new List<OrderLine>();
            foreach (var item in lines)
            {
                list.Add(new OrderLine()
                {
                     id = item.Id,  
                     orderid = item.OrdersId,
                     productid = item.ProductsId,   
                     quantity = item.Quantity,
                    
                });
            }
            return list;
        }


        public List<Order> getAllOrders()
        {
            var db = new DatabaseContext();
            var lines = db.Orders.Include(c => c.Customers).Include(ol => ol.OrderLines).ToList();
            List<Order> list = new List<Order>();
            foreach (var item in lines)
            {             
                    
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId
                   
                 });
            }
            return list;
        }

       

        public Order findOrder(int id)
        {
            return null;
        }

        public bool checkOrder(int? id)
        {
            return false;
        }
    }
}