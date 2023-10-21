using Microsoft.AspNetCore.SignalR;

namespace real_time_chat_backend.Implementations;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine(user);
        Console.WriteLine(message);
        await Clients.All.SendAsync("ReceivedMessage", user, message);
    }
    
}