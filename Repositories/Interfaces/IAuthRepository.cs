using real_time_chat_backend.Requests;
using Supabase.Gotrue;

namespace real_time_chat_backend.Repositories.Interfaces;

public interface IAuthRepository
{
    public Task<Session> SignUp(SignUpRequest signUpRequest);
    public Task<Session> SignIn(SignInRequest signInRequest);
    public Task<Session> GetCurrentSession();
    public Task<Supabase.Gotrue.User> GetCurrentUser();
}