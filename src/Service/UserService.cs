using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly string _route;

    public UserService(HttpClient httpClient, string? route = null)
    {
        _httpClient = httpClient;
        _route = route ?? Routes.UserRoute;
    }
    
    public async Task<HttpResponseWrapper<UserDto>> Create(CreationUserRequest creationUser)
    {
        var definitiveRoute = _route + "/create";
        var response = await _httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(creationUser)
            .Build()
        );
        
        return await HttpResponseWrapper<UserDto>.Create(response);
    }
    
    public async Task<HttpResponseWrapper<UserDto>> Edit(string uuid, EditUser editUser)
    {
        var definitiveRoute = _route + "/edit/" + uuid;
        var response = await _httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(editUser)
            .Build());
        
        return await HttpResponseWrapper<UserDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<ICollection<UserDto>>> Search(string parametersAsUrl)
    {
        var definitiveRoute = _route + "/search" + parametersAsUrl;
        var response = await _httpClient.
            GetAsync(definitiveRoute);

        return await HttpResponseWrapper<ICollection<UserDto>>.Create(response);
    }


    public async Task<HttpResponseWrapper<UserDto>> Find(string uuid)
    {
        var definitiveRoute = _route + "/find/" + uuid;
        var response = await _httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<UserDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<UserDto>> Delete(string uuid)
    {
        var definitiveRoute = _route + "/delete/" + uuid;
        var response = await _httpClient.DeleteAsync(definitiveRoute);

        return await HttpResponseWrapper<UserDto>.Create(response);
    }
    
    
}

