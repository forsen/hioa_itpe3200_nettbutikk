using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Customer
    {
       
        public int id { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig fornavn")]
        public String firstname { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig etternavn")]
        public String lastname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]@[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$)", ErrorMessage = "Ugyldig email")]
        public String email { get; set; }
         [Display(Name = "Telefonnummer")]
         [RegularExpression(@"(^[0-9\+\(\)\s]{8,}$)", ErrorMessage = "Ugyldig telefonnummer")]
         [Required(ErrorMessage = "Telefonnummer må oppgis")]
        public String phonenumber { get; set; }
        [Display(Name = "Adresse")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        public String address { get; set; }
        [Display(Name = "Postnummer")]
        [RegularExpression(@"(^[0-9]{4})", ErrorMessage = "Ugyldig postnummer")]
        [Required(ErrorMessage = "Postnummer må oppgis")]
        public String postalcode { get; set; }
        [Display(Name = "Poststed")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ]+$)", ErrorMessage = "Ugyldig poststed")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public String postalarea { get; set; }
        [Display(Name = "Passord")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ]{8,}$)", ErrorMessage = "Ugyldig passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public String password { get; set; }
        public byte[] hashpassword { get; set; }

        public ShoppingCart shoppingcart;
        public List<Orders> Orders { get; set; }

    }
}