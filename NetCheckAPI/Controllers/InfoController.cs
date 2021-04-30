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
            var validatorChain = new IPAddressValidator(new DomainNameValidator(null));
            ValidationResponse response = new ValidatorService(validatorChain).ValidateNetworkID(address);

            Result[] results;
            if (response.isValid) {
                results = await new AdapterTaskService(new AdapterFactory()).ExecuteAdapterTasks(services.Split(',').ToList(), address);
            } else {
                var data = new Dictionary<string, string>();
                data.Add(nameof(response.isValid), response.isValid.ToString());
                data.Add(nameof(response.message), response.message);
                results = new Result[] { new Result { Service = "Validation", Data = data } };
            }
            Info info = new Info {
                Address = address,
                Services = services,
                Results = results,
            };
            return info;
        }
    }
}
