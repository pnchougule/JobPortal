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
    public class JdRepository:IJdRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public JdRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }
        public async Task<List<Job>> GetAllJds()
        {
           var getAllJds = await _jobPortalDbContext.Jobs.ToListAsync();
            return getAllJds;
        }

        public async Task<Job> GetJdById(int id)
        {
            var getJd =  await _jobPortalDbContext.Jobs.Where(x=>x.JobId == id).FirstOrDefaultAsync();
            return getJd;
        }

        public async Task InsertJd(Job jd)
        {
            var addJd = await _jobPortalDbContext.Jobs.AddAsync(jd);
            await _jobPortalDbContext.SaveChangesAsync();
        }

        public async Task UpdateJd(Job jd)
        {
            var updateJd = await _jobPortalDbContext.Jobs.FirstOrDefaultAsync(e=>e.JobId == jd.JobId);
            if (updateJd != null)
            {
                updateJd.CompanyName = jd.CompanyName;
                updateJd.Experience = jd.Experience;
                updateJd.JobTitle = jd.JobTitle;
                updateJd.LinkedinUrl = jd.LinkedinUrl;
                updateJd.JoiningDate = jd.JoiningDate;
                updateJd.Description = jd.Description;
                updateJd.JobId = jd.JobId;
                updateJd.MandatorySkills = jd.MandatorySkills;
                updateJd.OptionalSkills = jd.OptionalSkills;
                updateJd.Certification = jd.Certification;
                updateJd.ExpiryOfRole = jd.ExpiryOfRole;
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteJd(int id)
        {
            var deleteJd = await _jobPortalDbContext.Jobs.Where(x=>x.JobId.Equals(id)).FirstOrDefaultAsync();
            if(deleteJd != null)
            {
                var data = _jobPortalDbContext.Jobs.Remove(deleteJd);
                await _jobPortalDbContext.SaveChangesAsync();
            }
        }

    }
}