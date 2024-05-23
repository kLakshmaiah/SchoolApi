using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Model.IResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolApi.Model.Response
{
    public class AuthService : IAuthService
    {
        SchoolContext Db;
        IConfiguration Configuration;

        public AuthService(SchoolContext context, IConfiguration configuration)
        {
            Db = context;
            Configuration = configuration;  
        }

         async Task<GetRefreshTokenViewModel> IAuthService.Login(Login login)
        {
            GetRefreshTokenViewModel  token = new GetRefreshTokenViewModel();
            User userName = await Db.Users.FirstOrDefaultAsync(s => s.UserName == login.Username);
            if (userName != null)
            {
                var role =await Db.Roles.FirstOrDefaultAsync(role => role.RoleId == userName.RoleId);
                if (role == null)
                {
                    return null;
                }
                else
                {
                    
                    var authclaims = new List<Claim>()
                    {
                     new Claim(ClaimTypes.Name, userName.UserName),
                     new Claim(ClaimTypes.Role,userName.Role.RoleName)
                    };
                   token.AccessToken =await GenerateToken(authclaims);
                    token.RefreshToken = GenerateRefreshToken();
                    var RefreshTokenValidityInMinutes = Convert.ToInt64(Configuration["JWTKey:RefreshTokenValidityInHours"]);

                    Token user = new Token()
                    {
                        UserName = userName.UserName,
                        RoleId = userName.RoleId,
                        RefreshToken = token.RefreshToken,
                        RefreshTokenExpiryTime = DateTime.Now.AddHours(RefreshTokenValidityInMinutes),
                    //    UserGuid=guid
                    };

                    var result = await Db.Tokens.AddAsync(user);
                    await Db.SaveChangesAsync();
                    return token;
                }
            }
            else
            {
                return null;
            }
           
        }


         async Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWTKey:Secret"]));
            var tokenexpirytimeInminutes = Convert.ToInt64(Configuration["JWTKey:TokenExpiryTimeInMinutes"]);
            var tokenDescriptor = new JwtSecurityToken
            (
                 Configuration["JWTKey:ValidIssuer"],
                Configuration["JWTKey:ValidAudience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(tokenexpirytimeInminutes),
                 new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return tokenHandler;
        }

        async Task<GetRefreshTokenViewModel> IAuthService.GetRefreshToken(GetRefreshTokenViewModel model)
        {
            GetRefreshTokenViewModel tokenModel = new GetRefreshTokenViewModel();
            var refreshtoken =await Db.Tokens.FirstOrDefaultAsync(t=>t.RefreshToken==model.RefreshToken);
     
            if (refreshtoken == null || refreshtoken.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }
            var role = await Db.Roles.FirstOrDefaultAsync(role => role.RoleId == refreshtoken.RoleId);

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name,refreshtoken.UserName),
               new Claim(ClaimTypes.Role,role.RoleName),
            };
            var newAccessToken =await GenerateToken(authClaims);
            var newRefreshToken = GenerateRefreshToken();                   
            tokenModel.AccessToken = newAccessToken;
            tokenModel.RefreshToken = newRefreshToken;
            var RefreshTokenValidityInMinutes = Convert.ToInt64(Configuration["JWTKey:RefreshTokenValidityInHours"]);
            refreshtoken.RefreshTokenExpiryTime=DateTime.Now.AddMinutes(RefreshTokenValidityInMinutes);
            Db.Tokens.Update(refreshtoken);
            Db.SaveChanges();
            return tokenModel;
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }

}
