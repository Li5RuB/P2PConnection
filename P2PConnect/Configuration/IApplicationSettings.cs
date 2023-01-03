using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Configuration
{
    public interface IApplicationSettings
    {
        int Port { get; set; }
    }
}
