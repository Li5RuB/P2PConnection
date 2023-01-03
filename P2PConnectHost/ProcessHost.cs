using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnectHost
{
    public class ProcessHost : IProcessHost
    {
        public async Task ProcessAsync(int port)
        {
            var runListener = true;
            
            var udpServer = new UdpClient(228);
            
            while (runListener)
            {
                var result = await udpServer.ReceiveAsync();

                var message = Encoding.UTF8.GetString(result.Buffer);

                Console.WriteLine(result.RemoteEndPoint.Address + ":" + result.RemoteEndPoint.Port);
            }
        }
    }
}