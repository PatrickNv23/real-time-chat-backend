using Microsoft.AspNetCore.Mvc;
using real_time_chat_backend.Entities;
using real_time_chat_backend.Responses;

namespace real_time_chat_backend.Controllers;

public class UserController : ApiController
{
    
    private readonly Supabase.Client _client;
    
    public UserController(Supabase.Client client)
    {
        this._client = client;
    }
    
    [HttpGet("GetAll")]
    public async Task<List<GetUserResponse>> GetAll()
    {
        var result = await this._client.From<User>().Get();
        var users = result.Models;

        var usersList = new List<GetUserResponse>();
        
        users.ForEach(user =>
        {
            var item = new GetUserResponse
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
                ProfilePhotoUrl = user.ProfilePhotoUrl
            };

            usersList.Add(item);
        });

        return usersList;
    }
}