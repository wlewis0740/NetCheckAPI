using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class IPAddressValidator : BaseNetworkValidator
    {
        public IPAddressValidator(INetworkValidator validator) : base(validator) { }
        public override ValidationResponse Validate(string networkID) {
            Regex rgx = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (rgx.IsMatch(networkID)) {
                return new ValidationResponse { isValid = true, message = "Valid IP Address" };
            } else {
                return base.Validate(networkID);
            }
        }
    }
}