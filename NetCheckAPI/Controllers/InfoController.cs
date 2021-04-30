using NetCheckAPI.Factories;
using NetCheckAPI.Models;
using NetCheckAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace NetCheckAPI.Controllers
{
    public class InfoController : ApiController
    {
        // GET: api/Results/5
        [ResponseType(typeof(Info))]
        public async Task<Info> Get(string address, string services = "default")
        {
            Info info = new Info {
                Address = address,
                Services = services,
                Results = await new AdapterTaskService(new AdapterFactory()).ExecuteAdapterTasks(services.Split(',').ToList(), address),
                /*Results = new Result[] {
                    new Result { Service = "Hello Service", Data = new Dictionary<string, string>() { { "message", "Hello World" } }}
                }*/
            };
            return info;
        }
    }
}
