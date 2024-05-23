using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;

namespace JobPortalAPI.Service.Interfaces
{
    public interface IJdService
    {
        Task<List<Job>> GetAllJds();
        Task<Job> GetJdById(int id);
        Task InsertJd(Job jd);
        Task UpdateJd(Job jd);
        Task DeleteJd(int id);
    }
}