using P2PConnect.Configuration;
using P2PConnectClient;
using P2PConnectHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P2PConnect
{
    public class ConnectProcessing
    {
        private readonly IApplicationSettings _applicationSettings;
        private readonly IProcessClient _processClient;
        private readonly IProcessHost _processHost;

        public ConnectProcessing(IApplicationSettings applicationSettings, IProcessClient processClient, IProcessHost processHost)
        {
            _applicationSettings = applicationSettings;
            _processClient = processClient;
            _processHost = processHost;
        }

        /// <summary>
        /// args:
        /// -h host
        /// -c client
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task ProcessAsync(string[] args)
        {
            switch (args[0])
            {
                case "-h":
                    await _processHost.ProcessAsync(_applicationSettings.Port);
                    break;
                case "-c":
                    await _processClient.ProcessAsync();
                    break;
                default:
                    break;
            }
        }
    }
}
