using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pokemon_tcg_collection_api.Context;
using pokemon_tcg_collection_api.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_tcg_collection_api.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly MyAppContext _context;

        public UserService(IConfiguration configuration, MyAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Bearer:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserEntity> InsertUserAsync(UserEntity user)
        {
            var userToInsert = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var insertedUser = await _context.Users
                .Where(u => u.Id == userToInsert.Entity.Id)
                .FirstOrDefaultAsync();

            return insertedUser;
        }
    }
}
