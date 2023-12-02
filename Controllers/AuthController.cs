using Microsoft.AspNetCore.Mvc;
using real_time_chat_backend.Requests;
using real_time_chat_backend.Services.Interfaces;
using Supabase.Gotrue;

namespace real_time_chat_backend.Controllers;

public class AuthController : ApiController
{
    private readonly IAuthService _authService;
    private readonly Supabase.Client _clientAux;
    
    public AuthController(IAuthService authService,Supabase.Client client)
    {
        this._authService = authService;
        this._clientAux = client;
    }

    [HttpPost("SignUp")]
    public async Task<Session> SignUp([FromBody] SignUpRequest signUpRequest)
    {
        return await this._authService.SignUp(signUpRequest);
    }
    
    [HttpPost("SignIn")]
    public async Task<Session> SignIn([FromBody] SignInRequest signInRequest)
    {
        return await this._authService.SignIn(signInRequest);
    }
    
    [HttpGet("GetCurrentSession")]
    public async Task<Session> GetCurrentSession()
    {
        return await this._authService.GetCurrentSession();
    }
    
    [HttpGet("GetCurrentUser")]
    public async Task<Supabase.Gotrue.User> GetCurrentUser()
    {
        return await this._authService.GetCurrentUser();
    }
    
    [HttpPost("GetCurrentUserWithToken")]
    public async Task<Supabase.Gotrue.User> GetCurrentUserWithToken([FromBody] string token)
    {
        var user = await _clientAux.Auth.GetUser(token);
            
        return await Task.FromResult(user);
    }
}