using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class IPAddressValidator : BaseNetworkValidator, INetworkValidator
    {
        public override string Validate(string networkID) {
            Regex rgx = new Regex(@"");
            if (rgx.IsMatch(networkID)) {
                return "Valid IP Address";
            } else {
                return base.Validate(networkID);
            }
        }
    }
}