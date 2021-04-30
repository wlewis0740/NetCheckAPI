using System;
using Google.Apis.DomainsRDAP.v1;
using Google.Apis.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Models;

namespace NetCheckAPI.Tests.Adapters
{
    [TestClass]
    public class RDAPAdapterTests
    {
        [TestMethod]
        public void TestGetResults() {
            string address = "www.google.com";
            IAdapter rdapAdapter = new RDAPAdapter(new DomainsRDAPService(new BaseClientService.Initializer {
                //ApplicationName = "NetCheckAPI",
                ApiKey = "AIzaSyD_X2XHMV_45fyXHQkoCjWFG7hvQkkc3bE",
            }));

            Result result = rdapAdapter.GetResults(address);

            Assert.IsTrue(result.Data.TryGetValue(GeoIPAdapter.CountryCode, out string actualCode));
            Assert.AreEqual("US", actualCode);
        }
    }
}
