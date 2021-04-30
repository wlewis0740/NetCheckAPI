using System;   
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class DomainNameValidator : BaseNetworkValidator
    {
        public DomainNameValidator(INetworkValidator validator) : base(validator) { }

        public override ValidationResponse Validate(string networkID) {
            if (Uri.CheckHostName(networkID) == UriHostNameType.Dns) {
                return new ValidationResponse { isValid = true, message = "Valid Domain Name" };
            } else {
                return base.Validate(networkID);
            }
        }
    }
}