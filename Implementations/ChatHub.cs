using Microsoft.AspNetCore.SignalR;

namespace real_time_chat_backend.Implementations;

public class ChatHub : Hub
{
    public async Task SendMessageToAll(string user, string message)
    {
        await Clients.All.SendAsync("ReceivedMessageToAll", user, message);
    }

    public async Task SendMessageToCaller(string message)
    {
        await Clients.Caller.SendAsync("ReceivedMessageToCaller", message);
    }

    public async Task SendMessageToUser(string connectionId, string message)
    {
        await Clients.User(connectionId).SendAsync("ReceivedMessageToUser", message);
    }

    public async Task JoinGroup(string groupName)
    {
        Console.WriteLine(Context.ConnectionId);
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessageToGroup(string groupName, string message)
    {
        await Clients.Group(groupName).SendAsync("ReceivedMessageToGroup", message);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }
    
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        base.OnDisconnectedAsync(exception);
    }
}