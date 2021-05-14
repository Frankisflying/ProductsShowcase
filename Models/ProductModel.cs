using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsShowcase.Models
{
    public class ProductModel
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost to Customer")]
        public decimal Price { get; set; }
        [DisplayName("What you get...")]
        public string Description { get; set; }
    }
}
