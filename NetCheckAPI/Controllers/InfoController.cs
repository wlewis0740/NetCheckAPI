using NetCheckAPI.Adapters;
using NetCheckAPI.Factories;
using NetCheckAPI.Models;
using NetCheckAPI.Services;
using NetCheckAPI.Validators;
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
        const string defaultServices = nameof(PingAdapter) + "," + nameof(ReverseDNSAdapter);

        // GET: api/Results/5
        [ResponseType(typeof(Info))]
        public async Task<Info> Get(string address, string services = defaultServices)
        {
            var ipAddressValidator = new IPAddressValidator();
            var domainNameValidator = new DomainNameValidator();
            new ValidatorService(ipAddressValidator.SetNext(domainNameValidator));

            Info info = new Info {
                Address = address,
                Services = services,
                Results = await new AdapterTaskService(new AdapterFactory()).ExecuteAdapterTasks(services.Split(',').ToList(), address),
            };
            return info;
        }
    }
}
