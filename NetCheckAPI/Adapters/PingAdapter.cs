using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace NetCheckAPI.Adapters
{
    public class PingAdapter : IAdapter
    { 
        Ping ping;

        public PingAdapter(Ping ping) {
            this.ping = ping;
        }

        public Result GetResult(string address) {
            var data = new Dictionary<string, string>();
            PingReply reply = ping.Send(address);
            if (reply.Status == IPStatus.Success) {
                data.Add("address", reply.Address.ToString());
                data.Add("roundTripTime", reply.RoundtripTime.ToString());
                data.Add("timeToLive", reply.Options.Ttl.ToString());
                data.Add("bufferSize", reply.Buffer.Length.ToString());
            } else {
                data.Add("error", "Ping Failed");
            }
            return new Result() { service = nameof(Ping), data = data };
        }
    }
}