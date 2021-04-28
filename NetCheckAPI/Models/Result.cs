using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class Result
    {
        public string address { get; set; }
        public string services { get; set; }
        public string message { get;  set; }
    }
}