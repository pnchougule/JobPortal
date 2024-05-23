using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;

namespace JobPortalAPI.Service
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public AdminService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            var getAllAdmins = await _unitOfWorkRepository.adminRepository.GetAllAdmins();
            return getAllAdmins;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            var getAdmin = await _unitOfWorkRepository.adminRepository.GetAdminById(id);
            return getAdmin;
        }

        public async Task InsertAdmin(Admin admin)
        {
            await _unitOfWorkRepository.adminRepository.InsertAdmin(admin);
        }

        public async Task UpdateAdmin(Admin admin)
        {
            await _unitOfWorkRepository.adminRepository.UpdateAdmin(admin);
        }
        public async Task DeleteAdmin(int id)
        {
            await _unitOfWorkRepository.adminRepository.DeleteAdmin(id);
        }
    }
}