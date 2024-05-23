using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;
using JobPortalAPI.SP_Models;

namespace JobPortalAPI.Service
{
    public class MasterService:IMasterService
    {
        private readonly IUnitOfWorkRepository  _unitOfWorkRepository;
        public  MasterService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<JobsByFunction> GetJobsByFunctionName(string name)
        {
            return await _unitOfWorkRepository.masterRepo.GetJobsByFunctionName(name);
        }
    }
}