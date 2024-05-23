using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;
using SchoolApi.Model.Response;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService Auth;

        public AuthenticationController(IAuthService authService)
        {
            Auth = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Token([FromBody] Login login)
        {
           // throw new NotImplementedException();
            if (string.IsNullOrWhiteSpace(login.Username) && string.IsNullOrWhiteSpace(login.Username))
            {
                return BadRequest("Invalid payload");
            }
          var response=  await Auth.Login(login);
          if(response==null)
            {
                return BadRequest(login);
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody]GetRefreshTokenViewModel model)
        {
            
                if (model is null)
                {
                    return BadRequest("Invalid client request");
                }

                var result = await Auth.GetRefreshToken(model);
                if (result == null)
                    return BadRequest("InvalidaTokens");

                return Ok(result);
            
        }
    }
}
