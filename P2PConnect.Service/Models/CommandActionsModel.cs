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
        public CommandActionsModel(IPEndPoint iPEndPoint, string message)
        {
            IPEndPoint = iPEndPoint;
            this.message = message;
        }

        public IPEndPoint IPEndPoint { get; set; }

        public string message { get; set; }
    }
}
