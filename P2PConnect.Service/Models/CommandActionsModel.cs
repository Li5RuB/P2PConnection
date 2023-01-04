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
        public CommandActionsModel(IPEndPoint iPEndPoint)
        {
            IPEndPoint = iPEndPoint;
        }

        public IPEndPoint IPEndPoint { get; set; }

        public object? obj { get; set; }

        public string? message { get; set; }

        public int? port { get; set; }
    }
}
