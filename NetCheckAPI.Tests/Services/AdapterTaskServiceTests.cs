using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Adapters;
using NetCheckAPI.Factories;
using NetCheckAPI.Models;
using NetCheckAPI.Services;

namespace NetCheckAPI.Tests.Services
{
    [TestClass]
    public class AdapterTaskServiceTests
    {
        [TestMethod]
        public async Task TestExecuteAdapterTasks() {
            var service = new AdapterTaskService(new AdapterFactoryStub());

            var results = await service.ExecuteAdapterTasks(new List<string> { "service1", "service2" }, "address");

            Assert.AreEqual(2, results.Length);
        }

        [TestMethod]
        public async Task TestExecuteAdapterTasks_EmptyServiceList() {
            var service = new AdapterTaskService(new AdapterFactoryStub());

            var results = await service.ExecuteAdapterTasks(new List<string>(), "address");

            Assert.AreEqual(0, results.Length);
        }

        private class AdapterStub : IAdapter
        {
            public Result GetResults(string address) {
                return new Result { Service = "stub", Data = null };
            }
        }
        private class AdapterFactoryStub : IAdapterFactory
        {
            public IAdapter GetAdapter(string adapterName) {
                return new AdapterStub();
            }
        }
    }

}
