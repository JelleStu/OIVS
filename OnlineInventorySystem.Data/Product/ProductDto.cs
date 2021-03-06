﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineInventorySystem.Data
{
    public class ProductDto
    {
        public int productId { get; set; }

        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public int quantity { get; set; }
        public decimal productPrice { get; set; }
        public int companyID { get; set; }
    }
}
