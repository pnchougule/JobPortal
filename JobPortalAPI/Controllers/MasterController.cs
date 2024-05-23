using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Service.Interfaces;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public MasterController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        
        [HttpGet]
        [Route("GetJobsByFunctionName")]
        public async Task<ActionResult<JobsByFunction>> GetJobsByFunctionName(string name)
        {
            var getAdmin = await _unitOfWorkService.masterService.GetJobsByFunctionName(name);
            return Ok(getAdmin);
        }
    }
}