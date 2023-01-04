using P2PConnect.Service.Interfaces;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace P2PConnectClient
{
    public class ProcessClient : IProcessClient
    {
        private readonly IReceiveService _receiveService;

        public ProcessClient(IReceiveService receiveService)
        {
            _receiveService = receiveService;
        }

        public async Task ProcessAsync()
        {
            var startClient = true;
            while (startClient)
            {
                var result = await _receiveService.ReceiveAsync();
            }
        }
    }
}