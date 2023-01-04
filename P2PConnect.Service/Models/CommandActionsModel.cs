using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Service.Models
{
    public class CommandActionsModel
    {
        public CommandActionsModel(UdpReceiveResult? receiveResult, int? port)
        {
            this.receiveResult = receiveResult;
            this.port = port;
        }

        public CommandActionsModel(object? obj)
        {
            this.obj = obj;
        }

        public CommandActionsModel(string? message)
        {
            this.message = message;
        }

        public CommandActionsModel(UdpReceiveResult? receiveResult, object? obj, string? message)
        {
            this.receiveResult = receiveResult;
            this.obj = obj;
            this.message = message;
        }

        public UdpReceiveResult? receiveResult { get; set; }

        public IPEndPoint IPEndPoint { get; set; }

        public CommandActionsModel(IPEndPoint iPEndPoint)
        {
            IPEndPoint = iPEndPoint;
        }

        public object? obj { get; set; }

        public string? message { get; set; }

        public int? port { get; set; }
    }
}
