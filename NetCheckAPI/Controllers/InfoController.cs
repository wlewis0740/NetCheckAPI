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
    public class InfoController : ApiController
    {
        // GET: api/Results/5
        [ResponseType(typeof(Info))]
        public Info Get(string address, string services = "default")
        {
            Info info = new Info {
                address = address,
                services = services,
                results = new Result[] {
                    new Result { service = "Hello Service", data = new Dictionary<string, string>() { { "message", "Hello World" } }}
                }
            };
            return info;
        }
    }
}
