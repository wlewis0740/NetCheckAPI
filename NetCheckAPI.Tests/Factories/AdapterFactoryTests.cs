using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Factories;

namespace NetCheckAPI.Tests.Factories
{
    [TestClass]
    public class AdapterFactoryTests
    {
        [TestMethod]
        public void GetAdapterTest() {
            IAdapterFactory factory = new AdapterFactory();

            IAdapter actualAdapter = factory.GetAdapter(nameof(PingAdapter));

            Assert.AreEqual(typeof(PingAdapter), actualAdapter.GetType());
        }

        [TestMethod]
        public void GetAdapterTest_UnknownAdapter() {
            IAdapterFactory factory = new AdapterFactory();

            Assert.ThrowsException<InvalidOperationException>(() => {
                IAdapter actualAdapter = factory.GetAdapter("UnknownAdapter");       
            });
        }
    }
}
