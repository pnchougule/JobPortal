using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.SP_Models;

namespace JobPortalAPI.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee employee);
       Task<List<EmployeeInfo>> GetAllEmployee();
       Task<EmployeeInfo> GetEmployeeById(int id);
       Task UpdateEmployee(Employee employee);
       Task DeleteEmployeeById(int id);
    }
}