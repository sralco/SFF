using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SFF.Web.Hubs
{
    public class AssociationHub : Hub
    {
        public async Task Send()
        {
            await Clients.Others.SendAsync("Updated");
        }
    }
}