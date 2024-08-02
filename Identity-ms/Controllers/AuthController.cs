using Identity_ms.JWT;
using Identity_ms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Identity_ms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IJwtTokenService jwtTokenService) : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Post(LoginViewModel login)
        {
            var token = jwtTokenService.GenerateAuthToken(login);
            return token is null ? Unauthorized() : Ok(token);
        }
    }
}
