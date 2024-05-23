using JobPortalAPI.Models;

namespace JobPortalAPI.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task InsertAdmin(Admin admin);
        Task UpdateAdmin(Admin admin);
        Task DeleteAdmin(int id);
    }
}