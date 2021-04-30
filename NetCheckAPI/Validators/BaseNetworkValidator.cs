using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Validators
{
    public abstract class BaseNetworkValidator : INetworkValidator
    {
        private INetworkValidator _next;

        public BaseNetworkValidator(INetworkValidator validator) {
            _next = validator;
        }

        public virtual ValidationResponse Validate(string networkID) {
            return _next != null ?_next.Validate(networkID) : new ValidationResponse { isValid = false, message = "Invalid Network Identifier" };
        }
    }
}