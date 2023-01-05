using P2PConnect.Service.Interfaces;
using P2PConnect.Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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
        private List<HostModel> _hosts = new List<HostModel>();

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

                if (commandActions.ContainsKey(message.Split(' ')[0]))
                {
                    commandActions[message.Split(' ')[0]].Invoke(new CommandActionsModel(result.RemoteEndPoint, message));
                }
            }
        }

        private void Init()
        {
            commandActions.Add("Ping", this.Pong);
            commandActions.Add("HostList", this.SendHostList);
            commandActions.Add("Connect", this.ConnectClients);
            commandActions.Add("BecomeHost", this.CreateHost);
            commandActions.Add("StopBeingHost", this.RemoveHost);
            commandActions.Add("Help", this.Help);
        }

        private async void Help(CommandActionsModel obj)
        {
            var message = string.Join("\n", commandActions.Keys.ToList().Select(x => x.ToString()));
            await _sendService.SendAsync(obj.IPEndPoint, message);
        }

        private void RemoveHost(CommandActionsModel obj)
        {
            _hosts.Remove(_hosts.First(x => x.IPEndPoint.Address == obj.IPEndPoint.Address));
        }

        private async void SendHostList(CommandActionsModel obj)
        {
            var message = string.Join("\n", _hosts.Select(x => x.ToString()));
            await _sendService.SendAsync(obj.IPEndPoint, message);
        }

        private async void ConnectClients(CommandActionsModel obj)
        {
            var c1 = _hosts.First(x => x.Name == obj.message).IPEndPoint;
            await _sendService.SendAsync(obj.IPEndPoint, $"{c1.Address}:{c1.Port}");
            await _sendService.SendAsync(c1, $"{obj.IPEndPoint.Address}:{obj.IPEndPoint.Port}");
        }

        private async void CreateHost(CommandActionsModel obj)
        {
            _hosts.Add(new HostModel(obj.IPEndPoint, obj.message.Split(' ')[1]));
            await _sendService.SendAsync(obj.IPEndPoint, "YouHost");
        }

        private async void Pong(CommandActionsModel c)
        {
            await _sendService.SendAsync(c.IPEndPoint, "Pong");
        }
    }
}