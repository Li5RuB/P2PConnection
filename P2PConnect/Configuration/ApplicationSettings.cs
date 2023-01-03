using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect.Configuration
{
    public class ApplicationSettings : IApplicationSettings
    {
        public int Port { get; set; }

        public void Initialize(IConfiguration configuration) 
        {
            Port = configuration.GetValue<int>("port");
        }
    }
}
