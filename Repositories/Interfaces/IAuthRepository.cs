using real_time_chat_backend.Requests;

namespace real_time_chat_backend.Repositories.Interfaces;

public interface IAuthRepository
{
    public Task SignUp(SignUpRequest signUpRequest);
}