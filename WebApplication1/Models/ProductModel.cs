using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public string brand { get; set; }

        public string name { get; set; }

        public int quantity { get; set; }

        public float price { get; set; }

        public string image { get; set; }

        public string description { get; set; }


    }
}