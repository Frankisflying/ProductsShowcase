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
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {
        ProductsDAO productsDAO;
        public ProductControllerAPI() 
        {
            productsDAO = new ProductsDAO();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        {
            //HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();
            return productsDAO.GetAllProducts();
        }


        [HttpDelete("Delete/{Id}")]
        public ActionResult<int> Delete(int Id)
        {
            ProductModel product = productsDAO.GetProductById(Id);
            int DeletedId = productsDAO.Delete(product);
            return DeletedId;
        }


        [HttpPost("InsertOne")]
        // post action
        // expecting a product in json format in the body of the request
        
        public ActionResult<int> ProcessCreate(ProductModel product)
        {
            int newId = productsDAO.Insert(product);
            return newId;
        }


        [HttpPut("ProcessEdit")]
        // put request
        // expect a json formatted object in the body of the request. Id number must match the product being edited.
        public ActionResult<ProductModel> ProcessEdit(ProductModel product)
        {
            productsDAO.Update(product);
            return productsDAO.GetProductById(product.Id);
        }


        // The optional parameter is enclosed with {}
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchResults(string searchTerm) 
        {            
            List<ProductModel> productList = productsDAO.SearchProducts(searchTerm);
            
            return productList;
        }


        [HttpGet("ShowDetails/{Id}")]
        public ActionResult<ProductModel> ShowDetails(int id) 
        {
            return productsDAO.GetProductById(id);
        }
    }
}
