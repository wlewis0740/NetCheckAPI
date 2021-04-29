using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace NetCheckAPI.Adapters
{
    public class ReverseDNSAdapter : IAdapter
    {
        public const string HostName = "hostName";
        public const string AddressList = "addressList";

        public Result GetResult(string address) {
            var data = new Dictionary<string, string>();
            var host = Dns.GetHostEntry(address);
            data.Add(HostName, host.HostName);
            data.Add(AddressList, string.Join(",", host.AddressList.Select(x => x.ToString())));
            return new Result { Service = nameof(ReverseDNSAdapter), Data = data };
        }
    }
}