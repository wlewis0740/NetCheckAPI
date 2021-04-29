using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCheckAPI.Adapters
{
    public interface IAdapter
    {
        Result GetResult(string address);
    }
}