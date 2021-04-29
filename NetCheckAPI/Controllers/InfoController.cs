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
                Address = address,
                Services = services,
                Results = new Result[] {
                    new Result { Service = "Hello Service", Data = new Dictionary<string, string>() { { "message", "Hello World" } }}
                }
            };
            return info;
        }
    }
}
