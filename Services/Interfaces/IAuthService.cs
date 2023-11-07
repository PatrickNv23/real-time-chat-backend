using real_time_chat_backend.Requests;
using Supabase.Gotrue;

namespace real_time_chat_backend.Services.Interfaces;

public interface IAuthService
{
    public Task<Session> SignUp(SignUpRequest signUpRequest);
    public Task<Session> SignIn(SignInRequest signInRequest);
    public Task<Session> GetCurrentSession();
}