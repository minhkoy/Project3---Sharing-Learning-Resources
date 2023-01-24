using Microsoft.AspNetCore.SignalR;

namespace OfficialProject3.Hubs
{
    public class UserOnlineHub : Hub
    {
        public static int onlineUsersCounter = 0;

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void SendOnlineUsersCounter()
        {
            Clients.All.SendAsync("GetOnlineUsersCounter", onlineUsersCounter);
        }
        public override Task OnConnectedAsync()
        {
            onlineUsersCounter++;
            SendOnlineUsersCounter();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUsersCounter--;
            SendOnlineUsersCounter();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
