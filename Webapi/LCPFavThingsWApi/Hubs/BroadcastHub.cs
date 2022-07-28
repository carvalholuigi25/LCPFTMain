using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LCPFavThingsWApi.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
