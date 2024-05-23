using JobPortalAPI.Models;

namespace JobPortalAPI.Service.Interfaces
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task InsertAdmin(Admin Admin);
        Task UpdateAdmin(Admin Admin);
        Task DeleteAdmin(int id); 
    }
}