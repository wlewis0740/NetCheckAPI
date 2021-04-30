using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Validators;

namespace NetCheckAPI.Tests.Validators
{
    [TestClass]
    public class DomainNameValidatorTests
    {
        [TestMethod]
        public void TestValidate_valid() {
            TestValidate("test.com", true);
        }

        [TestMethod]
        public void TestValidate_invalid() {
            TestValidate("test", false);
        }

        private void TestValidate(string networkId, bool isValid) {
            var validator = new DomainNameValidator(null);

            var response = validator.Validate(networkId);

            Assert.AreEqual(isValid, response.isValid);
        }
    }
}
