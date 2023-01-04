using P2PConnect.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Service.Services
{
    public class SendService : ISendService
    {
        private UdpClient _udpClient;
        public SendService(UdpClient udpClient)
        {
            _udpClient = udpClient;
        }

        public async Task<int> SendAsync(IPEndPoint iPEndPoint, string message)
        {
            var bufer = Encoding.UTF8.GetBytes(message);

            var result = await _udpClient.SendAsync(bufer, iPEndPoint);

            return result;
        }
    }
}
