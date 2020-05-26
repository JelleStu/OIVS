using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineInventorySystem.Data
{
    public class Productview
    {
        [HiddenInput]
        public int productId { get; set; }
        [DisplayName("Product naam")]
        public string productName { get; set; }
        [DisplayName("Beschrijving")]
        public string productDescription { get; set; }
        [DisplayName("Categorie")]
        public string productCategory { get; set; }
        [DisplayName("Hoeveelheid")]
        public int quantity { get; set; }
        [DisplayName("Prijs")]
        public decimal productPrice { get; set; }
        public int companyID { get; set; }
    }
}
