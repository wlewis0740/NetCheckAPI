using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Models
{
    public class Info
    {
        public string Address { get; set; }
        public string Services { get; set; }
        public Result[] Results { get; set; }
    }
}