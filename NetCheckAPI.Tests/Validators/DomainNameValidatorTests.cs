using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCheckAPI.Validators;

namespace NetCheckAPI.Tests.Validators
{
    [TestClass]
    public class DomainNameValidatorTests
    {
        [TestMethod]
        public void TestValidate_validDomainName() {
            TestValidate("test.com", true);
        }

        [TestMethod]
        public void TestValidate_invalidDomainName() {
            TestValidate("test", false);
        }

        private void TestValidate(string networkId, bool isValid) {
            var validator = new DomainNameValidator(null);

            var response = validator.Validate(networkId);

            Assert.AreEqual(isValid, response.isValid);
        }
    }
}
