using AutoMapper;
using Case.DTOs;
using Case.Models;
using Case.ViewModels;

namespace Case.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<CreateUser, User>();

        CreateMap<UpdateUser, User>();
        CreateMap<User, UserViewModel>();
    }
}
