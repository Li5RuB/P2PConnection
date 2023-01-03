using System.Threading.Tasks;

namespace P2PConnectHost
{
    public interface IProcessHost
    {
        Task ProcessAsync(int port);
    }
}
