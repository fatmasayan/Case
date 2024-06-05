using AutoMapper;
using Case.DTOs;
using Case.Models;
using Case.Repository;
using Case.ViewModels;

namespace Case.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository; //içerik değişir interface imza imza değişmez
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public async Task<bool> CreateUserAsync(CreateUser createUser)
        {
            var user = _mapper.Map<User>(createUser);
            var result = await _userRepository.AddAsync(user);

            return result;
        }

        public async Task<UserViewModel> GetUserAsync(int id)
        {
            var user = await _userRepository.GetAsync(e => e.Id == id);
            var result = _mapper.Map<UserViewModel>(user);

            return result;
        }

        public async Task<bool> UpdateUserAsync(UpdateUser updateUser)
        {
            var user = _mapper.Map<User>(updateUser);
            var result = await _userRepository.UpdateAsync(user);

            return result;
        }
    }
}
