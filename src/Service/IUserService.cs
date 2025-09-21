using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public interface IUserService 
{
    
    Task<HttpResponseWrapper<UserDto>> Create(CreationUserRequest creationUser);

    Task<HttpResponseWrapper<UserDto>> Find(string uuid);
    
    Task<HttpResponseWrapper<UserDto>> Delete(string uuid);

    Task<HttpResponseWrapper<UserDto>> Edit(string uuid, EditUser editUser);
    Task<ICollection<UserDto>> Search(string? name,
        string? email,
        bool? searchByIsDesactive);
    
}