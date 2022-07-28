using Microsoft.AspNetCore.SignalR;

namespace LCPFavThingsWebsite.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string msg)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, msg);
        }
    }
}
