using Microsoft.AspNetCore.Mvc;
using real_time_chat_backend.Requests;
using real_time_chat_backend.Services.Interfaces;

namespace real_time_chat_backend.Controllers;

public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost("SignUp")]
    public async Task SignUp([FromBody] SignUpRequest signUpRequest)
    {
        await this._authService.SignUp(signUpRequest);
    }
}