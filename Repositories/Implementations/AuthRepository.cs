using real_time_chat_backend.Repositories.Interfaces;
using real_time_chat_backend.Requests;
using Supabase.Gotrue;

namespace real_time_chat_backend.Repositories.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly Supabase.Client _client;

    public AuthRepository(Supabase.Client client)
    {
        this._client = client;
    }

    public async Task<Session> SignUp(SignUpRequest signUpRequest)
    {
        return await _client.Auth.SignUp(signUpRequest.Email, signUpRequest.Password);
    }

    public async Task<Session> SignIn(SignInRequest signInRequest)
    {
        return await _client.Auth.SignIn(signInRequest.Email, signInRequest.Password);
    }
}