using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.SP_Models;

namespace JobPortalAPI.Repository.Interfaces
{
    public interface IMasterRepository
    {
        Task<JobsByFunction> GetJobsByFunctionName(string name);
    }
}