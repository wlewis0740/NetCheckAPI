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
        public async Task<HttpResponseMessage> Get(string address, string services = defaultServices)
        {
            var validatorChain = new IPAddressValidator(new DomainNameValidator(null));
            ValidationResponse response = new ValidatorService(validatorChain).ValidateNetworkID(address);

            if (response.isValid) {
                Info info = new Info {
                    Address = address,
                    Services = services,
                    Results = await new AdapterTaskService(new AdapterFactory()).ExecuteAdapterTasks(services.Split(',').ToList(), address),
                };
                return Request.CreateResponse(HttpStatusCode.OK, info);
            } else {
                InvalidParameterResponse tmp = new InvalidParameterResponse {
                    Address = address,
                    Services = services,
                    ParameterValidation = response,
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, tmp);
            }
        }
    }
}
