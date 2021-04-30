using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class DomainNameValidator : BaseNetworkValidator
    {
        public DomainNameValidator(INetworkValidator validator) : base(validator) { }

        public override ValidationResponse Validate(string networkID) {
            Regex rgx = new Regex(@"^([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}$");
            if (rgx.IsMatch(networkID)) {
                return new ValidationResponse { isValid = true, message = "Valid Domain Name" };
            } else {
                return base.Validate(networkID);
            }
        }
    }
}