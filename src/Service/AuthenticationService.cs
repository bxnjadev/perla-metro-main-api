using perla_metro_main_api.Service;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Dto;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly string _route;

    public AuthenticationService(HttpClient httpClient, string? route = null)
    {
        _httpClient = httpClient;
        _route = route ?? Routes.AuthRoute;
    }

    public async Task<HttpResponseWrapper<string>> Login(Credentials credentials)
    {
        Console.WriteLine("Lanzado una llamada a: ");
        Console.WriteLine(_route);
        var response = await _httpClient.PostAsync(_route, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(credentials).
            Build());

        return await HttpResponseWrapper<string>.Create(response);
    }
}