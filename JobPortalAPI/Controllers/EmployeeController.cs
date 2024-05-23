using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Service.Interfaces;
using JobPortalAPI.SP_Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private IUnitOfWorkService _unitOfWorkService;
        public EmployeeController(IUnitOfWorkService unitOfWork){
            _unitOfWorkService=unitOfWork;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            var getAllEmployee = await _unitOfWorkService.employeeService.GetAllEmployee();
            return Ok(getAllEmployee);
        }
        
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var getEmployee = await _unitOfWorkService.employeeService.GetEmployeeById(id);
            return Ok(getEmployee);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
           
            await _unitOfWorkService.employeeService.AddEmployee(employee);
           return Ok("Employee added successfully");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            await _unitOfWorkService.employeeService.UpdateEmployee(employee);
            return Ok("Employee updated successfully");
        }

        [HttpDelete]
        [Route("DeleteEmployeeById")]
        public async Task<ActionResult> DeleteEmployeeById(int id){
            await _unitOfWorkService.employeeService.DeleteEmployeeById(id);
            return Ok("Employee deleted successfully");
        }
    }
}