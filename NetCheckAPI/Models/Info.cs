using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class Info
    {
        public string address { get; set; }
        public string services { get; set; }
        public Result[] results { get; set; }
    }
}