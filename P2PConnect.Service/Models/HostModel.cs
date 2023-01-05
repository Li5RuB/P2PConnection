using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace P2PConnect.Service.Models
{
    public class HostModel
    {
        public HostModel(IPEndPoint iPEndPoint, string name)
        {
            IPEndPoint = iPEndPoint;
            Name = name;
        }

        public IPEndPoint IPEndPoint { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
