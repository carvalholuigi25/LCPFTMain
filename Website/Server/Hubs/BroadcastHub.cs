using LCPFavThingsWebsite.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace LCPFavThingsWebsite.Server.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
