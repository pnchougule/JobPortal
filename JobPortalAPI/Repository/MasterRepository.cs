using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Data;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.SP_Models;
using Dapper;

namespace JobPortalAPI.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private JobPortalDbContext _context;
        public MasterRepository(JobPortalDbContext context)
        {
            _context = context;
        }
        public async Task<JobsByFunction> GetJobsByFunctionName(string name)
        {
            return await _context.Functions
                        .Where(f => f.IsActive && f.FunctionName == name)
                        .Include(f => f.Fu_Jo_Ros)
                        .ThenInclude(fjr => fjr.Jobs)
                        .Select(f => new JobsByFunction
                        {
                            FunctionName = f.FunctionName,
                            Count = f.Fu_Jo_Ros.Select(fjr => fjr.Jobs).Count(j => j.IsActive),
                            JobNames = f.Fu_Jo_Ros.Select(fjr => fjr.Jobs).Where(j => j.IsActive).Select(j => j.JobTitle).ToList()
                        })
                        .FirstOrDefaultAsync();
        }
    }
}