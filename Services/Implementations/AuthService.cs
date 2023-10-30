using real_time_chat_backend.Repositories.Interfaces;
using real_time_chat_backend.Requests;
using real_time_chat_backend.Services.Interfaces;
using Supabase.Gotrue;

namespace real_time_chat_backend.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        this._authRepository = authRepository;
    }

    public async Task<Session> SignUp(SignUpRequest signUpRequest)
    {
        return await this._authRepository.SignUp(signUpRequest);
    }

    public async Task<Session> SignIn(SignInRequest signInRequest)
    {
        return await this._authRepository.SignIn(signInRequest);
    }
}