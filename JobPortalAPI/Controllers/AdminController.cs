using Microsoft.AspNetCore.Mvc;
using JobPortalAPI.Models;
using JobPortalAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JobPortalAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController: ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public AdminController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet]
        [Route("GetAllAdmins")]
        public async Task<ActionResult> GetAllAdmins()
        {
            var getAllAdmins = await _unitOfWorkService.adminService.GetAllAdmins();
            return Ok(getAllAdmins);
        }
        
        [HttpGet]
        [Route("GetAdminById")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var getAdmin = await _unitOfWorkService.adminService.GetAdminById(id);
            return Ok(getAdmin);
        }

        [HttpPost]
        [Route("AddAdmin")]
        public async Task<ActionResult> AddAdmin(Admin admin)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWorkService.adminService.InsertAdmin(admin);
                return Ok("Admin added successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        [Route("UpdateAdmin")]
        public async Task<ActionResult> UpdateAdmin(Admin admin)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWorkService.adminService.UpdateAdmin(admin);
                return Ok("Admin updated successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteAdmin")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _unitOfWorkService.adminService.DeleteAdmin(id);
            return Ok("Admin deleted successfully!");
        }      
    }
}