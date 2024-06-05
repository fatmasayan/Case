using Case.DTOs;
using Case.ViewModels;

namespace Case.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUser createUser);
        Task<bool> UpdateUserAsync(UpdateUser updateUser);

        Task<UserViewModel> GetUserAsync(int id);
        
    }
}
