using NetCheckAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class InvalidParameterResponse {
        public string Address { get; set; }
        public string Services { get; set; }
        public ValidationResponse ParameterValidation {get; set;}
    }
}