using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Routing;

namespace NetCheckAPI.Adapters
{
    public class PingAdapter : IAdapter
    {
        public const string Address = "address";
        public const string RoundTripTime = "roundTripTime";
        public const string TimeToLive = "timeToLive";
        public const string BufferSize = "bufferSize";
        private readonly Ping _ping;

        public PingAdapter(Ping ping) {
            this._ping = ping;
        }

        public Result GetResult(string address) {
            var data = new Dictionary<string, string>();
            PingReply reply = _ping.Send(address);
            if (reply.Status == IPStatus.Success) {
                data.Add(Address, reply.Address.ToString());
                data.Add(RoundTripTime, reply.RoundtripTime.ToString());
                data.Add(TimeToLive, reply.Options.Ttl.ToString());
                data.Add(BufferSize, reply.Buffer.Length.ToString());
            } else {
                data.Add("error", "Ping Failed");
            }
            return new Result() { Service = nameof(PingAdapter), Data = data };
        }
    }
}