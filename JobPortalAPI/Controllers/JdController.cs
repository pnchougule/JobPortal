using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JdController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public JdController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet]
        [Route("GetAllJds")]
        public async Task<ActionResult<List<Job>>> GetAllJds()
        {
            var getAllJds = await _unitOfWorkService.jdService.GetAllJds();
            return Ok(getAllJds);
        }
        
        [HttpGet]
        [Route("GetJdById")]
        public async Task<ActionResult<Job>> GetJdById(int id)
        {
            var getJd = await _unitOfWorkService.jdService.GetJdById(id);
            return Ok(getJd);
        }

        [HttpPost]
        [Route("AddJd")]
        public async Task<ActionResult> AddJd(Job jd)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWorkService.jdService.InsertJd(jd);
                return Ok("Added Successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        [Route("UpdateJd")]
        public async Task<ActionResult> UpdateJd(Job jd)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWorkService.jdService.UpdateJd(jd);
                return Ok("Added Successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteJd")]
        public async Task<ActionResult> DeleteJd(int id)
        {
            await _unitOfWorkService.jdService.DeleteJd(id);
            return Ok("Deleted Successfully!");
        }    
    }
}