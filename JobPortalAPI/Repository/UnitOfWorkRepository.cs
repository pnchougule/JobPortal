using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Data;

namespace JobPortalAPI.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private JobPortalDbContext _context;
        private IConfiguration _configuration;
        public IMasterRepository masterRepo {get; private set;}
        public IAdminRepository adminRepository {get; private set;}
        public IEmployeeRepository employeeRepository{get;private set;}
        public IJdRepository jdRepository { get; private set;}
        public IUsersRepository usersRepository { get; private set;}
        public UnitOfWorkRepository(JobPortalDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            masterRepo = new MasterRepository(_context);
            adminRepository=new AdminRepository(_context);
            employeeRepository = new EmployeeRepository(_context);
            jdRepository = new JdRepository(_context);
            usersRepository = new UsersRepository(_context,_configuration);
        }
    }
}