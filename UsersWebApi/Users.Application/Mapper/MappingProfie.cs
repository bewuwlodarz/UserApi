using AutoMapper;
using Users.Application.Functions.Addresses.Commands.CreateAddress;
using Users.Application.Functions.Addresses.Queries.GetAddressesList;
using Users.Application.Functions.UserProfileSettings.Commands.CreateUserProfileSetting;
using Users.Application.Functions.UserProfileSettings.Queries.GetUserProfileSetting;
using Users.Application.Functions.Users;
using Users.Application.Functions.Users.Commands.CreateUser;
using Users.Application.Functions.Users.Commands.DeleteUser;
using Users.Application.Functions.Users.Commands.UpdateUser;
using Users.Domain.Entities;

namespace Users.Application.Mapper
{
    public class MappingProfie : Profile
    {
        public MappingProfie()
        {
            CreateMap<User, UserInListViewModel>().ReverseMap();
            CreateMap<User, UserDetailViewModel>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<UserProfileSetting, UserProfileSettingDto>().ReverseMap();
            CreateMap<Address, AddressInListViewModel>().ReverseMap();
            
            CreateMap<UserProfileSetting, UserProfileSettingListViewModel>().ReverseMap();
            
            CreateMap<UserProfileSetting, CreateUserSettingProfileCommand>().ReverseMap();
            
            
            CreateMap<User, CreateUserCommand>().ReverseMap();
            
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
        }
    }
}
