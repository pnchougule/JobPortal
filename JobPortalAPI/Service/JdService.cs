using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;

namespace JobPortalAPI.Service
{
    public class JdService:IJdService
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public JdService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<List<Job>> GetAllJds()
        {
            var getAllJds = await _unitOfWorkRepository.jdRepository.GetAllJds();
            return getAllJds;
        }

        public async Task<Job> GetJdById(int id)
        {
            var getJd = await _unitOfWorkRepository.jdRepository.GetJdById(id);
            return getJd;
        }

        public async Task InsertJd(Job jd)
        {
            await _unitOfWorkRepository.jdRepository.InsertJd(jd);
        }

        public async Task UpdateJd(Job jd)
        {
            await _unitOfWorkRepository.jdRepository.UpdateJd(jd);
        }
        public async Task DeleteJd(int id)
        {
            await _unitOfWorkRepository.jdRepository.DeleteJd(id);
        }
    }
}