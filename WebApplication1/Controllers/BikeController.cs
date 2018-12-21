using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Test.Models;
using WebApplication1.Models;

namespace Test.Controllers
{
    [Authorize]
    public class BikeController : ApiController
    {
       public static bikeConnection bc = new bikeConnection();

        // GET: api/getBikes
        [Route("api/getBikes"), HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {            
            return Ok(bc.getBikes());
        }

        // GET: api/getCartProds
        [Route("api/getCartProds"), HttpGet]
        public IHttpActionResult Get(string user)
        {
            return Ok(bc.getCartProds(user));
        }

        // GET: api/addProdToCart
        [Route("api/addProdToCart"), HttpGet]
        public IHttpActionResult Get(string user, int productID, int quantity)
        {
            return Ok(bc.addProdToCart(productID, quantity, user));
        }

        // GET: api/deleteProdFromCart
        [Route("api/deleteProdFromCart"), HttpGet]
        public IHttpActionResult Get(string user, int productID)
        {
            return Ok(bc.deleteProdFromCart(productID, user));
        }


        // POST api/addProduct
        [Route("api/addProduct")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public IHttpActionResult addProduct(ProductModel product)
        {
            if(User.Identity.GetUserName().Equals("admin"))
                return Ok(bc.addProduct(product.brand, product.name, product.description, product.image, product.quantity, product.price));

            return null;

        }

        [Route("api/createOrder"), HttpGet]
        public IHttpActionResult Get(string username, float summ)
        {            
            return Ok(bc.createOrder(username, summ));
        }
            
    }
}
