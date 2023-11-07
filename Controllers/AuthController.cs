using Microsoft.AspNetCore.Mvc;
using real_time_chat_backend.Requests;
using real_time_chat_backend.Services.Interfaces;
using Supabase.Gotrue;

namespace real_time_chat_backend.Controllers;

public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
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
}