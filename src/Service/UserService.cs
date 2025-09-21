using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public class UserService(
    HttpClient httpClient,
    string route = Routes.UserRoute) : IUserService
{
    
    public async Task<HttpResponseWrapper<UserDto>> Create(CreationUserRequest creationUser)
    {
        var definitiveRoute = route + "/create";
        var response = await httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(creationUser)
            .Build()
        );
        
        return await HttpResponseWrapper<UserDto>.Create(response);
    }
    
    public async Task<HttpResponseWrapper<UserDto>> Edit(string uuid, EditUser editUser)
    {
        var definitiveRoute = route + "/edit/" + uuid;
        var response = await httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(editUser)
            .Build());
        
        return await HttpResponseWrapper<UserDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<ICollection<UserDto>>> Search(string parametersAsUrl)
    {
        var definitiveRoute = route + "/search" + parametersAsUrl;
        var response = await httpClient.
            GetAsync(definitiveRoute);

        return await HttpResponseWrapper<ICollection<UserDto>>.Create(response);
    }


    public async Task<HttpResponseWrapper<UserDto>> Find(string uuid)
    {
        var definitiveRoute = route + "/find/" + uuid;
        var response = await httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<UserDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<UserDto>> Delete(string uuid)
    {
        var definitiveRoute = route + "/delete/" + uuid;
        var response = await httpClient.DeleteAsync(definitiveRoute);

        return await HttpResponseWrapper<UserDto>.Create(response);
    }
    
    
}

