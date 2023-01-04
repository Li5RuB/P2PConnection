using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Service.Interfaces
{
    public interface ISendService
    {
        Task<int> SendAsync(IPEndPoint iPEndPoint, string message);
    }
}
