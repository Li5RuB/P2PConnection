using System;
using System.Threading.Tasks;

namespace P2PConnectClient
{
    public class ProcessClient : IProcessClient
    {
        public async Task ProcessAsync()
        {
            Console.WriteLine("Start Client");
        }
    }
}