using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace BotEx_Api.Service
{
    public class TokenService
    {
        private readonly byte[] _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(string secretKey, string issuer, string audience)
        {
            _secretKey = GenerateRandomBytes(32); // Генерируем 128-битный ключ
            _issuer = issuer;
            _audience = audience;
        }

        private byte[] GenerateRandomBytes(int v)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[v];
                rng.GetBytes(bytes);
                return bytes;
            }
        }

        public string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
