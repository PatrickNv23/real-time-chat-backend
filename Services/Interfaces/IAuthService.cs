using real_time_chat_backend.Requests;

namespace real_time_chat_backend.Services.Interfaces;

public interface IAuthService
{
    public Task SignUp(SignUpRequest signUpRequest);
}