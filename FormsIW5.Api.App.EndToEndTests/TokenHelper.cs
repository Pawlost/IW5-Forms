using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FormsIW5.Api.App.EndToEndTests
{
    public class TokenHelper
    {
        public static string GenerateToken(string secretKey, string issuer, string audience, string username, int expirationMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                new Claim("sub", username),
                new Claim("scope", "cookbookapi"),
                new Claim("scope", "profile"),
                new Claim("scope", "offline_access"),
                new Claim("client_id", "cookbookclient"),
                new Claim("role", "admin"),
                ]),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
