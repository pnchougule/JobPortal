using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalAPI.Repository.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IMasterRepository masterRepo {get;}
        IAdminRepository adminRepository {get;}
        IEmployeeRepository employeeRepository{get;}
        IJdRepository jdRepository { get;}
        IUsersRepository usersRepository { get;}
    }
}