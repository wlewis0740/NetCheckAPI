using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class Result
    {
        public string Service { get; set; }
        public Dictionary<string, string> Data { get;  set; }
    }
}