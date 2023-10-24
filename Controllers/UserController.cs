using Microsoft.AspNetCore.Mvc;
using real_time_chat_backend.Entities;
using real_time_chat_backend.Responses;

namespace real_time_chat_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    
    private readonly Supabase.Client _client;
    
    public UserController(Supabase.Client client)
    {
        this._client = client;
    }
    
    [HttpGet("GetAll")]
    public async Task<List<GetAllUsersResponse>> GetAll()
    {
        var result = await this._client.From<User>().Get();
        var users = result.Models;

        var usersList = new List<GetAllUsersResponse>();
        
        users.ForEach(user =>
        {
            var item = new GetAllUsersResponse
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                UpdateDate = user.UpdateDate,
                UserCode = user.UserCode,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };

            usersList.Add(item);
        });

        return usersList;
    }
}