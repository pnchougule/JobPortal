namespace JobPortalAPI.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        IMasterService masterService {get;}
        IAdminService adminService {get;}
        IEmployeeService employeeService{get;}
        IJdService jdService { get;}
        IUsersService usersService { get;}
    }
}