using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Data;
using JobPortalAPI.SP_Models;
using Microsoft.Extensions.Options;

namespace JobPortalAPI.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private JobPortalDbContext _context;
        private IOptions<JwtSettings> _jwtSettings;
        public IMasterRepository masterRepo { get; private set; }
        public IAdminRepository adminRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set; }
        public IJdRepository jdRepository { get; private set; }
        public IUsersRepository usersRepository { get; private set; }
        public UnitOfWorkRepository(JobPortalDbContext context, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            masterRepo = new MasterRepository(_context);
            adminRepository = new AdminRepository(_context);
            employeeRepository = new EmployeeRepository(_context);
            jdRepository = new JdRepository(_context);
            usersRepository = new UsersRepository(_context, _jwtSettings);
        }
    }
}