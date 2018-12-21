﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Authorize/*(Roles = "admin")*/]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("api/getUsers"), HttpGet]
        public IEnumerable<Models.ApplicationUser> Get()
        {
            Models.ApplicationDbContext UsersContext = new Models.ApplicationDbContext();
            
            var Users = UsersContext.Users.ToList();
            //Users.ForEach(Console.WriteLine);

            return Users;
          
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
