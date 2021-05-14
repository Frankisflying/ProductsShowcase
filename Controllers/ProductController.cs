using ProductsShowcase.Models;
using ProductsShowcase.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsShowcase.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            //HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();
            ProductsDAO products = new ProductsDAO();
            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm) 
        {
            ProductsDAO products = new ProductsDAO();
            
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            
            return View("index", productList);
        }

        public IActionResult ShowDetails(int id) 
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult SearchForm() 
        {
            return View();
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }

        // Routing from a controller to an action of the controller
        // IActionResult 
        public IActionResult Message()
        {
            // ViewBag is not shared across methods
            ViewBag.TestMessage = "It'shared!";
            // It will be expecting a View called Message
            return View();
        }

        // Passing param on URL use the format of {action/controller name}?{variableName}={value}&{variableName}={value}
        public IActionResult Welcome(string name, int secretNumber = 13)
        {
            // ViewBag is not the recommended way to pass variables
            ViewBag.Name = name;
            ViewBag.SecretNumber = secretNumber;
            return View();
        }
    }
}
