using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class Result
    {
        public string service { get; set; }
        public Dictionary<string, string> data { get;  set; }
    }
}