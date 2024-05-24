using JobPortalAPI.Models;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Identity.Data;

namespace JobPortalAPI.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task InsertUser(User jd);
        Task UpdateUser(User jd);
        Task DeleteUser(int id);
        Task<LoginResponse> Login(SP_Models.LoginRequest loginRequest);
    }
}
