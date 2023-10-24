using Microsoft.AspNetCore.SignalR;

namespace real_time_chat_backend.Implementations;

public class ChatHub : Hub
{
    public async Task SendMessageToAll(string user, string message)
    {
        await Clients.All.SendAsync("SendMessageToAll", user, message);
    }

    public async Task SendMessageToCaller(string message)
    {
        await Clients.Caller.SendAsync("SendMessageToCaller", message);
    }

    public async Task SendMessageToUser(string connectionId, string message)
    {
        await Clients.User(connectionId).SendAsync(message);
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessageToGroup(string groupName, string message)
    {
        await Clients.Group(groupName).SendAsync(message);
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