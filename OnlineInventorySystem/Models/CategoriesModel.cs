using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInventorySystem.Data;

namespace OnlineInventorySystem.Models
{
    public class CategoriesModel
    {
        public static List<string> productcategories;

        public List<string> SetList(List<Productview> products)
        {
            productcategories = new List<string>();
            foreach (var product in products)
            {
                if (productcategories.Contains(product.productCategory) == false)
                {
                    productcategories.Add(product.productCategory);
                }
                else
                {
                    continue;
                }
            }
            return productcategories;
        }
    }
}
