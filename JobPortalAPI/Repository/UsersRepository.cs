using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JobPortalAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        private readonly JwtSettings _jwtSettings;

        public UsersRepository(JobPortalDbContext jobPortalDbContext, IOptions<JwtSettings> jwtSettings)
        {
            _jobPortalDbContext = jobPortalDbContext;
            _jwtSettings = jwtSettings.Value;
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
            var existingUser = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteUser(int id)
        {
            var userToDelete = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToDelete != null)
            {
                _jobPortalDbContext.Users.Remove(userToDelete);
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }

        public async Task<LoginResponse> Login(SP_Models.LoginRequest loginRequest)
        {
            var user = await _jobPortalDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginRequest.Email);
            // Replace with your user validation logic
            if (loginRequest.Email == user.Email && loginRequest.Password == user.Password)
            {
                var token = GenerateJwtToken(user);

                var userDetails = new { Username = user.UserName, Email = user.Email };
                var encryptedDetails = EncryptUserDetails(userDetails);

                return new LoginResponse
                {
                    Token = token,
                    EncryptedUserDetails = encryptedDetails
                };
            }
            return null;

        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string EncryptUserDetails(object userDetails)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(userDetails);
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key.Substring(0, 16)); // Use a 16 byte key for AES-128
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(json);
                        }
                    }

                    var iv = aes.IV;
                    var encrypted = ms.ToArray();
                    var result = Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(encrypted);
                    return result;
                }
            }
        }

    }
}
