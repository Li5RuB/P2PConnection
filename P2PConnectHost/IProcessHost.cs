using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnectHost
{
    public interface IProcessHost
    {
        Task ProcessAsync(int port);
    }
}
