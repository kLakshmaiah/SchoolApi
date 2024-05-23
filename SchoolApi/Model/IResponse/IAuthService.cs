using System.Security.Claims;

namespace SchoolApi.Model.IResponse
{
    public interface IAuthService
    {
        Task<GetRefreshTokenViewModel> Login(Login login);
        Task<GetRefreshTokenViewModel> GetRefreshToken(GetRefreshTokenViewModel getRefresh);
    }
}
