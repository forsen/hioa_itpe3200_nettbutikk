using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Product
    {
        [Display(Name="Varenummer")]
        public int itemnumber { get; set; }

        [Display(Name = "Produktnavn")]
        [Required(ErrorMessage = "Produktnavn må oppgis")]
        public String name { get; set; }

        [Display(Name = "Beskrivelse")]
        [Required(ErrorMessage = "Beskrivelse må oppgis")]
        public String description { get; set; }

        [Display(Name = "Detaljert beskrivelse")]
        public String longDescription { get; set; }

        [Display(Name = "Pris")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage = "Pris må oppgis")]
        public int price { get; set; }

        [Display(Name = "Volum")]
        [Required(ErrorMessage = "Volum må oppgis")]
        public double volum { get; set;}

        [Display(Name = "Pris per liter")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double pricePerLitre { get; set; }

        [Display(Name = "Produsent")]
        [Required(ErrorMessage = "Produsent må oppgis")]
        public String producer { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori må oppgis")]
        public String category { get; set; }

        public String subCategory { get; set; }
        public int subCategoryid { get; set; }
        public String country { get; set; }
        public int categoryid { get; set; }


        private int _quantity = 1;
        public int quantity 
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
         
    }
}