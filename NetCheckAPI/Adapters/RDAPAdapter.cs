using Google.Apis.DomainsRDAP.v1;
using Google.Apis.Services;
using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Adapters
{
    public class RDAPAdapter : IAdapter
    {
        private readonly DomainsRDAPService _rdapService;

        public RDAPAdapter(DomainsRDAPService rdapService) {
            _rdapService = rdapService;
        }

        public Result GetResults(string address) {
            var data = new Dictionary<string, string>();
            var result = _rdapService.Domain.Get(address).Execute();
            data.Add("result", result.ToString());
            return new Result() { Service = nameof(RDAPAdapter), Data = data };
        }
    }
}