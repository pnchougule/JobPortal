using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Repository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public AdminRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }
       
        public async Task<List<Admin>> GetAllAdmins()
        {
            var getAllAdmins = await _jobPortalDbContext.Admins.ToListAsync();
            return getAllAdmins;
        }

        public async Task<Admin> GetAdminById(int id)
        {
            var getAdmin =  await _jobPortalDbContext.Admins.Where(x=>x.AdminId == id).FirstOrDefaultAsync();
            return getAdmin;
        }

        public async Task InsertAdmin(Admin admin)
        {
            await _jobPortalDbContext.Admins.AddAsync(admin);
            await _jobPortalDbContext.SaveChangesAsync();
        }

        public async Task UpdateAdmin(Admin admin){
            var adminToUpdate = await _jobPortalDbContext.Admins.FirstOrDefaultAsync(e=>e.AdminId == admin.AdminId);
            if (adminToUpdate != null)
            {
                adminToUpdate.AdminName = admin.AdminName;
                adminToUpdate.CompanyName = admin.CompanyName;
                adminToUpdate.EmailId = admin.EmailId;
                adminToUpdate.LinkedinUrl = admin.LinkedinUrl;
                adminToUpdate.JoiningDate = admin.JoiningDate;
                adminToUpdate.IsActive = admin.IsActive;
                adminToUpdate.CreatedBy = admin.CreatedBy;
                adminToUpdate.CreatedOn = admin.CreatedOn;
                adminToUpdate.ModifiedBy = admin.ModifiedBy;
                adminToUpdate.ModifiedOn = admin.ModifiedOn;
                adminToUpdate.CityId = admin.CityId;
                adminToUpdate.FunctionId = admin.FunctionId;
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAdmin(int id)
        {
            var deleteAdmin = await _jobPortalDbContext.Admins.Where(x=>x.AdminId.Equals(id)).FirstOrDefaultAsync();
            if(deleteAdmin != null)
            {
                _jobPortalDbContext.Admins.Remove(deleteAdmin);
                await _jobPortalDbContext.SaveChangesAsync();
            }
        } 
    }
}