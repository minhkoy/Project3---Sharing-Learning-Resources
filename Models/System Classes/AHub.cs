using Microsoft.AspNetCore.SignalR;

namespace OfficialProject3.Models.System_Classes
{
    public class AHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
