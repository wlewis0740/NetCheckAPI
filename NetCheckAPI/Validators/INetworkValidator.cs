using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCheckAPI.Validators
{
    public interface INetworkValidator
    {
        ValidationResponse Validate(string networkID);
    }
}
