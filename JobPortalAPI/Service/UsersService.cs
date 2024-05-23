using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using JobPortalAPI.Service.Interfaces;

namespace JobPortalAPI.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public UsersService(IUnitOfWorkRepository unitOfWorkRepository) 
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var getAllUsers = await _unitOfWorkRepository.usersRepository.GetAllUsers();
            return getAllUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var userById = await _unitOfWorkRepository.usersRepository.GetUserById(id);
            return userById;
        }

        public async Task InsertUser(User user)
        {
            await _unitOfWorkRepository.usersRepository.InsertUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await _unitOfWorkRepository.usersRepository.UpdateUser(user);
        }
        public async Task DeleteUser(int id)
        {
            await _unitOfWorkRepository.usersRepository.DeleteUser(id);
        }

        public async Task<string> Login(string Email, string Password)
        {
            return await _unitOfWorkRepository.usersRepository.Login(Email, Password);
        }
    }
}
