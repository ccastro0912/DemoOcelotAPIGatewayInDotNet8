using Identity_ms.ViewModels;

namespace Identity_ms.JWT
{
    public interface IJwtTokenService
    {
        string? GenerateAuthToken(LoginViewModel login);
    }
}
