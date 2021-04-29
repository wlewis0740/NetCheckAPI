using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Models;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace NetCheckAPI.Tests.Adapters
{
    [TestClass]
    public class PingAdapterTests
    {
        [TestMethod]
        public void TestGetResults() {
            string address = "127.0.0.1";
            IAdapter adapter = new PingAdapter(new Ping());

            Result result  = adapter.GetResult(address);

            Assert.IsTrue(result.Data.TryGetValue(PingAdapter.Address, out string actualAddress));
            Assert.AreEqual(address, actualAddress);
        }
    }
}
