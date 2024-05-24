using JobPortalAPI.Models;
using JobPortalAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Authorization;


namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UsersController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var getAllUsers = await _unitOfWorkService.usersService.GetAllUsers();
            return Ok(getAllUsers);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var getUser = await _unitOfWorkService.usersService.GetUserById(id);
            return Ok(getUser);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.usersService.InsertUser(user);
                return Ok("User added successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.usersService.UpdateUser(user);
                return Ok("User updated successfully!");
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _unitOfWorkService.usersService.DeleteUser(id);
            return Ok("User deleted successfully!");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _unitOfWorkService.usersService.Login(loginRequest);
            if (token == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new { Token = token });
        }


    }
}
