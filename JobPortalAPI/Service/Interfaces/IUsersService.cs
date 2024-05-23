using JobPortalAPI.Models;

namespace JobPortalAPI.Service.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task InsertUser(User jd);
        Task UpdateUser(User jd);
        Task DeleteUser(int id);
        Task<string> Login(string email, string Password);
    }
}
