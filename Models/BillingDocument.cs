using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class BillingDocument
    {
        public Customer customer { get; set; }
        public Order order { get; set; }
        public ShoppingCart shoppingcart { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double exmva { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double mva { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int sum { get; set; }


    }
}