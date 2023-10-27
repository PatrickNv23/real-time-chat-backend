using real_time_chat_backend.Repositories.Interfaces;
using real_time_chat_backend.Requests;
using real_time_chat_backend.Services.Interfaces;

namespace real_time_chat_backend.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        this._authRepository = authRepository;
    }

    public async Task SignUp(SignUpRequest signUpRequest)
    {
        await this._authRepository.SignUp(signUpRequest);
    }
}