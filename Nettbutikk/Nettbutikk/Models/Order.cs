﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Order
    {
        [DisplayName("Ordrenummer")]
        public int id { get; set; }
        [DisplayName("Ordredato")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime orderdate { get; set; }
        public int customerid { get; set; }
        public List<OrderLine> orderLine { get; set; }
        // setter ikke opp en public Customer customer her, for vi antar at en kunde opprettes før en ordre, og ikke samtidig. 
        //public List<OrderLine> orderline { get; set; }
    }
}