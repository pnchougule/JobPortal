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
    public class EmployeeService:IEmployeeService
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public EmployeeService(IUnitOfWorkRepository unitOfWorkRepository){
            _unitOfWorkRepository=unitOfWorkRepository;
        }

        public async Task<List<EmployeeInfo>> GetAllEmployee(){
            return await _unitOfWorkRepository.employeeRepository.GetAllEmployee();
        }
        public async Task<EmployeeInfo> GetEmployeeById(int id){
            return await _unitOfWorkRepository.employeeRepository.GetEmployeeById(id);
        }
        public async Task AddEmployee(Employee employee){
            await _unitOfWorkRepository.employeeRepository.AddEmployee(employee);
        }
        public async Task UpdateEmployee(Employee employee){
            await _unitOfWorkRepository.employeeRepository.UpdateEmployee(employee);
        }
        public async Task DeleteEmployeeById(int id){
            await _unitOfWorkRepository.employeeRepository.DeleteEmployeeById(id);
        }
    }
}