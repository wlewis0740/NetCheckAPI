using NetCheckAPI.Models;
using Profit365.GeoIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Adapters
{
    public class GeoIPAdapter : IAdapter
    {
        public const string City = "city";
        public const string CountryCode = "countryCode";
        private readonly GeoLocationProvider _geoLocationProvider;

        public GeoIPAdapter(GeoLocationProvider geoLocationProvider) {
            _geoLocationProvider = geoLocationProvider;
        }

        public Result GetResults(string address) {
            var data = new Dictionary<string, string>();
            var geoData = _geoLocationProvider.GetLocationByIP(address);
            data.Add(City, geoData.city);
            data.Add(CountryCode, geoData.country_code);
            return new Result { Service = nameof(GeoIPAdapter), Data = data };
        }
    }
}