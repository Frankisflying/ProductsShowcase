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
        ProductsDAO productsDAO;
        public ProductController() 
        {
            productsDAO = new ProductsDAO();
        }


        public IActionResult Index()
        {
            //HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();
            return View(productsDAO.GetAllProducts());
        }


        public IActionResult Edit(int id)
        {
            ProductModel foundProduct = productsDAO.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }


        public IActionResult Delete(int Id)
        {
            ProductModel product = productsDAO.GetProductById(Id);
            productsDAO.Delete(product);
            return View("Index", productsDAO.GetAllProducts());
        }


        public IActionResult InputForm()
        {
            return View();
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


        public IActionResult ProcessCreate(ProductModel product)
        {
            productsDAO.Insert(product);
            return View("Index", productsDAO.GetAllProducts());
        }


        public IActionResult ProcessEdit(ProductModel product)
        {
            productsDAO.Update(product);
            return View("Index", productsDAO.GetAllProducts());
        }


        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            productsDAO.Update(product);
            return PartialView("_productCard", product);
        }


        public IActionResult SearchForm()
        {
            return View();
        }


        public IActionResult SearchResults(string searchTerm) 
        {            
            List<ProductModel> productList = productsDAO.SearchProducts(searchTerm);
            
            return View("index", productList);
        }


        public IActionResult ShowDetails(int id) 
        {
            return View(productsDAO.GetProductById(id));
        }


        public IActionResult ShowDetailsJSON(int id)
        {
            return Json(productsDAO.GetProductById(id));
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
