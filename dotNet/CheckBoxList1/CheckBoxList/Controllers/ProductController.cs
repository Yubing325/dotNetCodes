﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckBoxList.Models;

namespace CheckBoxList.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductModel product = new ProductModel();
            using (DBModels db = new DBModels())
            {
                product.Products = db.Products.ToList<Product>();
            }
            return View(product);
        }
        // POST: Product
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            var selectedProduct = model.Products.Where(x => x.IsChecked == true).ToList<Product>();          
         
            return Content(String.Join(" && ", selectedProduct.Select(x => x.ProductName)));
        }
    }
}