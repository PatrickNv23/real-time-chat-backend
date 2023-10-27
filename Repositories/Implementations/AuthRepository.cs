using real_time_chat_backend.Repositories.Interfaces;
using real_time_chat_backend.Requests;

namespace real_time_chat_backend.Repositories.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly Supabase.Client _client;

    public AuthRepository(Supabase.Client client)
    {
        this._client = client;
    }

    public async Task SignUp(SignUpRequest signUpRequest)
    {
        var session = await _client.Auth.SignUp(signUpRequest.Email, signUpRequest.Password);
    }
}