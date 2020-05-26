using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Logic;
using OnlineInventorySystem.Models;

namespace OnlineInventorySystem.Controllers
{
    public class ProductController : Controller
    {
        private ProductManagerView productManagerView = new ProductManagerView();
        private int CompanyID;

        public IActionResult Products(string category)
        {
            if (SessionCheckEmpty() == false)
            {
                if (category == null)
                {
                    
                    List<Productview> products = productManagerView.GetAllProducts(CompanyID);
                    CategoriesModel categories = new CategoriesModel();
                    categories.SetList(products);
                    productManagerView.GetSession(CompanyID);
                    return View(products);
                }
                else
                {
                    List<Productview> products = productManagerView.GetCategoryProduct(category, CompanyID);
                    productManagerView.GetSession(CompanyID);
                    return View(products);
                }
            }
            return View("~/Views/Start/Index.cshtml");
        }

        //GET requests
        public IActionResult DetailProduct(int id)
        {
            if (SessionCheckEmpty() == false)
            {
                Productview product = productManagerView.GetProductById(id);
                if (product != null)
                {
                    return View(product);
                } 
                return NotFound();
            }
            return View("~/Views/Start/Index.cshtml");
        }

        public IActionResult Edit(int id)
        {
            if (SessionCheckEmpty() == false)
            {
                Productview product = productManagerView.GetProductById(id);
                if (product != null)
                {
                    return View(product);
                }
                return NotFound();
            }
            return View("~/Views/Start/Index.cshtml");
        }


        public IActionResult Create()
        {
            if (SessionCheckEmpty() == false)
            {
                return View();
            }
            return View("~/Views/Start/Index.cshtml");
        }

        public IActionResult Delete(int id)
        {
            if (SessionCheckEmpty() == false)
            {
                Productview product = productManagerView.GetProductById(id);
                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    return NotFound(product);
                }
            }
            return View("~/Views/Start/Index.cshtml");
        }

        //End GET requests

        // POST requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productview product)
        {
            productManagerView.EditProduct(product.productId, product.productName,
                    product.productDescription, product.quantity, product.productPrice);
            return RedirectToAction("Products");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productview product)
        {
            int compnayIDproduct = Convert.ToInt32(HttpContext.Session.GetInt32("_CompanyID"));
            productManagerView.CreateProduct(product.productName, product.productDescription, product.quantity, product.productPrice, compnayIDproduct, product.productCategory);
            return RedirectToAction("Products");

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            productManagerView.DeleteProduct(id);
            return RedirectToAction("Products");
        }

        private bool SessionCheckEmpty()
        {
            CompanyID = Convert.ToInt32(HttpContext.Session.GetInt32("_CompanyID"));
            if (CompanyID != 0)
            {
                return false;
            }
            return true;  
        }
    }
}