using ShareMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShareMarket.Controllers.Api
{
    public class UsersController : ApiController
    {
        public UsersController()
        {

        }

        //GET api/customers
        public IEnumerable<User> GetUsers()
        {
            return;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
