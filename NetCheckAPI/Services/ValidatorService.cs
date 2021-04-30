using NetCheckAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Services
{
    public class ValidatorService
    {
        private readonly BaseNetworkValidator _validator;
        
        public ValidatorService(BaseNetworkValidator validator) {
            _validator = validator;
        }

        public ValidationResponse ValidateNetworkID(string networkID) {
            return _validator.Validate(networkID);
        }
    }
}