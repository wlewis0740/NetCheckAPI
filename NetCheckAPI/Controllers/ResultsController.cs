using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NetCheckAPI.Controllers
{
    public class ResultsController : ApiController
    {
        // GET: api/Results/5
        [ResponseType(typeof(Result))]
        public Result Get(string address, string services = "default")
        {
            var result = new Result {
                address = address,
                services = services,
                message = "Hello World"
            };
            return result;
        }
    }
}
