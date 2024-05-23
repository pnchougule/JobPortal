using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;

namespace JobPortalAPI.Service
{
    public class UnitOfWorkService:IUnitOfWorkService
    {
        private readonly IUnitOfWorkRepository  _unitOfWorkRepository;
        public IMasterService masterService {get; private set;}
        public IAdminService adminService {get; private set;}
        public IEmployeeService employeeService{get;private set;}
        public IJdService jdService { get;private set;}
        public IUsersService usersService { get; private set;}
        public  UnitOfWorkService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            masterService=new MasterService(_unitOfWorkRepository);
            adminService = new AdminService(_unitOfWorkRepository);
            employeeService=new EmployeeService(_unitOfWorkRepository);
            jdService=new JdService(_unitOfWorkRepository);
            usersService=new UsersService(_unitOfWorkRepository);
        }
    }
}