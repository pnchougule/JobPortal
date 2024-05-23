using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.SP_Models;

namespace JobPortalAPI.Service.Interfaces
{
    public interface IMasterService
    {
        Task<JobsByFunction> GetJobsByFunctionName(string name);
    }
}