using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Models;
using Profit365.GeoIP;

namespace NetCheckAPI.Tests.Adapters
{
    [TestClass]
    public class GeoIPAdapterTests
    {
        [TestMethod]
        public void TestGetResults() {
            string address = "www.gooogle.com";
            IAdapter geoIPAdapter = new GeoIPAdapter(new GeoLocationProvider());

            Result result = geoIPAdapter.GetResults(address);

            Assert.IsTrue(result.Data.TryGetValue(GeoIPAdapter.CountryCode, out string actualCode));
            Assert.AreEqual("US", actualCode);
        }
    }
}
