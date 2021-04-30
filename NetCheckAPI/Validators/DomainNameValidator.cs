using System;   
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class DomainNameValidator : BaseNetworkValidator, INetworkValidator
    {
        public override string Validate(string networkID) {
            if (Uri.CheckHostName(networkID) != UriHostNameType.Unknown) {
                return "Valid Domain Name";
            } else {
                return base.Validate(networkID);
            }
        }
    }
}