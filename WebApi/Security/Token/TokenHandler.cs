using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Security.Token
{
    public class TokenHandler:ITokenHandler
    {
        private TokenOptions _tokenOptions;
        private IUserService _userService;

        public TokenHandler(IOptions<TokenOptions>  tokenOptions, IUserService userService)
        {
            _tokenOptions = tokenOptions.Value;
            _userService = userService;
        }

        public string CreateRefreshToken()
        {
            var randBytes = new byte[32];
            using (var rnd=RandomNumberGenerator.Create())
            {
                rnd.GetBytes(randBytes);
                return Convert.ToBase64String(randBytes);
            }
        }


        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, $"{user.FirstName} {user.LastName}"));

            var operationClaims = _userService.GetUserOpeaClaims(user.Id);

            foreach (var claim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim.Name));
            }

            return claims;

           

        }


        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
            (
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: GetClaims(user)

            );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return new AccessToken()
            {
                Token = token,
                RefreshToken = CreateRefreshToken(),
                Expiration = accessTokenExpiration
            };
        }

        public void RefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
