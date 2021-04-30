using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Validators
{
    public class ValidationResponse
    {
        public bool isValid { get; set; }
        public string message { get; set; }
    }
}