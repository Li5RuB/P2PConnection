using P2PConnect.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect
{
    public class ConnectProcessing
    {
        private readonly IApplicationSettings _applicationSettings;

        public ConnectProcessing(IApplicationSettings applicationSettings) 
        {
            _applicationSettings = applicationSettings;
        }

        public async Task ProcessAsync()
        {
            Console.WriteLine("Goo!!");
        }
    }
}
