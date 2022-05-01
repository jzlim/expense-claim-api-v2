using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpenseClaimApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseClaimApi.Helpers
{
  public static class JwtHelper
  {
    public static string GenerateJwtToken(UserDTO user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var accessTokenSecret = "97cd3993b1105641878994f6f19b5c7487aac1696bebf50eec7c69f935c16cce007834128281422909aaee5dc7e383ff"; // temp
        var key = Encoding.ASCII.GetBytes(accessTokenSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("Id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
  }
}