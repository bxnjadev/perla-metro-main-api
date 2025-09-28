using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public class RouteService : IRouteService
{
    private readonly HttpClient _httpClient;
    private readonly string _route;

    public RouteService(HttpClient httpClient, string? route = null)
    {
        _httpClient = httpClient;
        _route = route ?? Routes.RoutesRoute;
    }
    public async Task<HttpResponseWrapper<CreationRouteRequest>> Create(CreationRouteRequest creationRoute)
    {
        var definitiveRoute = _route + "/";
        var response = await _httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(creationRoute)
            .Build()
        );

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<CreationRouteRequest>> GetAll()
    {
        var definitiveRoute = _route + "/";
        var response = await _httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<CreationRouteRequest>> Find(string uuid)
    {
        var definitiveRoute = _route + "/" + uuid;
        var response = await _httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<EditRoute>> EditRoute(string uuid, EditRoute editRoute)
    {
        var definitiveRoute = _route + "/" + uuid;
        var response = await _httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(editRoute)
            .Build());

        return await HttpResponseWrapper<EditRoute>.Create(response);
    }

    public async Task<HttpResponseWrapper<RouteDto>> Delete(string uuid)
    {
        var definitiveRoute = _route + "/" + uuid;
        var response = await _httpClient.DeleteAsync(definitiveRoute);

        return await HttpResponseWrapper<RouteDto>.Create(response);
    }
}