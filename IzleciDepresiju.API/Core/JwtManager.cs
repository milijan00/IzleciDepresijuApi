using IzleciDepresiju.Implementation.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IzleciDepresiju.Api.Core
{
    public class JwtManager
    {
        private readonly IzleciDepresijuDbContext _context;
        private readonly JwtSettings _settings;

        public JwtManager(IzleciDepresijuDbContext context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }

        public string MakeToken(string email, string password)
        {
            var user = _context.Users.Include(x => x.Role).ThenInclude(r => r.UseCases).FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }

            var useCases = _context.RolesUseCases.Where(x => x.RoleId == user.Role.Id).Select(x => x.UseCaseId).ToList();

            var actor = new JwtUser
            {
                Id = user.Id,
                //UseCaseIds = user.Role.UseCases.Select(x => x.UseCaseId).ToList(),
                UseCaseIds = useCases,
                Identity = user.Email,
                Email = user.Email
            };

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)),
                new Claim("Username", user.Username),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
