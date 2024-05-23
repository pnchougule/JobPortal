using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobPortalAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        private readonly IConfiguration _configuration;
        public UsersRepository(JobPortalDbContext jobPortalDbContext, IConfiguration configuration) 
        { 
            _jobPortalDbContext = jobPortalDbContext; 
            _configuration = configuration;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var getAllUsers = await _jobPortalDbContext.Users.ToListAsync();
            return getAllUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var userById = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userById;
        }

        public async Task InsertUser(User user)
        {
            await _jobPortalDbContext.Users.AddAsync(user);
            await _jobPortalDbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x=>x.Id== user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                existingUser.Email=user.Email;
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteUser(int id)
        {
            var userToDelete = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if (userToDelete != null) 
            {
                _jobPortalDbContext.Users.Remove(userToDelete);
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x=>x.Email==email);
            if (user != null && (user.Password == password))
            {
                return GenerateToken(user);
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
