using NetCheckAPI.Adapters;
using Profit365.GeoIP;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace NetCheckAPI.Factories
{
    public class AdapterFactory : IAdapterFactory
    {
        public IAdapter GetAdapter(string adapterName) {
            IAdapter adapter;
            switch (adapterName) {
                case nameof(PingAdapter):
                    adapter = new PingAdapter(new Ping());
                    break;
                case nameof(ReverseDNSAdapter):
                    adapter = new ReverseDNSAdapter();
                    break;
                case nameof(GeoIPAdapter):
                    adapter = new GeoIPAdapter(new GeoLocationProvider());
                    break;
                default:
                    throw new InvalidOperationException($"No adapter found for service {adapterName}");
            }
            return adapter;
        }
    }
}