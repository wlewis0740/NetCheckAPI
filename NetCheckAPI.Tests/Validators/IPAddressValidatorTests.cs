using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCheckAPI.Tests.Validators
{
    [TestClass]
    class IPAddressValidatorTests
    {
        [TestMethod]
        public void TestValidate_ValidIPAddress() {
            TestValidate("127.0.0.1", true);
        }

        [TestMethod]
        public void TestValidate_InvalidIPAddress() {
            TestValidate("127.0.0", false);
        }

        private void TestValidate(string networkId, bool isValid) {
            var validator = new IPAddressValidator(null);

            var response = validator.Validate(networkId);

            Assert.AreEqual(isValid, response.isValid);
        }
    }
}
