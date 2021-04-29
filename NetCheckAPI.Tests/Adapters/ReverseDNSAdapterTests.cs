using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Models;

namespace NetCheckAPI.Tests.Adapters
{
    [TestClass]
    public class ReverseDNSAdapterTests
    {
        [TestMethod]
        public void TestGetResults() {
            string hostname = "www.google.com";
            IAdapter reverseDNSAdapter = new ReverseDNSAdapter();

            Result result = reverseDNSAdapter.GetResult(hostname);

            Assert.IsTrue(result.Data.TryGetValue(ReverseDNSAdapter.HostName, out string actualHostName));
            Assert.AreEqual(hostname, actualHostName);
        }
    }
}
