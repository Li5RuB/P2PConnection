using P2PConnect.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Service.Services
{
    public class ReceiveService : IReceiveService
    {
        private UdpClient _udpClient;

        public ReceiveService(UdpClient udpClient)
        {
            _udpClient = udpClient;
        }

        public async Task<UdpReceiveResult> ReceiveAsync()
        {
            var result = await _udpClient.ReceiveAsync();
            return result;
        }
    }
}
