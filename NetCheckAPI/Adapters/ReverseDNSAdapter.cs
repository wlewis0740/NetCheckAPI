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

        public Result GetResults(string address) {
            var data = new Dictionary<string, string>();
            try {
                var host = Dns.GetHostEntry(address);
                data.Add(HostName, host.HostName);
                data.Add(AddressList, string.Join(",", host.AddressList.Select(x => x.ToString())));
            } catch(Exception e) {
                data.Add("error", e.Message);
            }
            return new Result { Service = nameof(ReverseDNSAdapter), Data = data };
        }
    }
}