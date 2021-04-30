using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Validators
{
    public abstract class BaseNetworkValidator : INetworkValidator
    {
        private INetworkValidator _next;

        public INetworkValidator SetNext(INetworkValidator validator) {
           return _next = validator;
        }

        public virtual string Validate(string networkID) {
            return _next != null ?_next.Validate(networkID) : "Invalid Network Identifier";
        }
    }
}