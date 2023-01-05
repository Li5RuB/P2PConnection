using P2PConnect.Service.Interfaces;
using P2PConnect.Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnectHost
{
    public class ProcessHost : IProcessHost
    {
        private readonly IReceiveService _receiveService;
        private readonly ISendService _sendService;

        private Dictionary<string, Action<CommandActionsModel>> commandActions = new Dictionary<string, Action<CommandActionsModel>>();

        public ProcessHost(IReceiveService receiveService, ISendService sendService)
        {
            _receiveService = receiveService;
            _sendService = sendService;
            Init();
        }

        public async Task ProcessAsync(int port)
        {
            var runhost = true;
            
            while (runhost)
            {
                var result = await _receiveService.ReceiveAsync();
                
                var message = Encoding.UTF8.GetString(result.Buffer);

                Console.WriteLine(result.RemoteEndPoint.Address + ":" + result.RemoteEndPoint.Port);

                if (commandActions.ContainsKey(message))
                {
                    commandActions[message].Invoke(new CommandActionsModel(result.RemoteEndPoint));
                }
            }
        }

        private async void Pong(CommandActionsModel c)
        {
            await _sendService.SendAsync(c.IPEndPoint, "Pong");
        }

        private void Init() 
        {
            commandActions.Add("Ping", this.Pong);
        }
    }
}