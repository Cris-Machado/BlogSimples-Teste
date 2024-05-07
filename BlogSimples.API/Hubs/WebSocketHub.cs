using Microsoft.AspNetCore.SignalR;

namespace BlogSimples.API.Hubs
{
    public class WebSocketHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
