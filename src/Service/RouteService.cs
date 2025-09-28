using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public class RouteService(
    HttpClient httpClient,
    string route = Routes.RoutesRoute
) : IRouteService
{
    public async Task<HttpResponseWrapper<CreationRouteRequest>> Create(CreationRouteRequest creationRoute)
    {
        var definitiveRoute = route + "/";
        var response = await httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(creationRoute)
            .Build()
        );

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<CreationRouteRequest>> GetAll()
    {
        var definitiveRoute = route + "/";
        var response = await httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<CreationRouteRequest>> Find(string uuid)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = await httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<CreationRouteRequest>.Create(response);
    }

    public async Task<HttpResponseWrapper<EditRoute>> EditRoute(string uuid, EditRoute editRoute)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = await httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(editRoute)
            .Build());
            
        return await HttpResponseWrapper<EditRoute>.Create(response);
    }

    public async Task<HttpResponseWrapper<RouteDto>> Delete(string uuid)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = await httpClient.DeleteAsync(definitiveRoute);

        return await HttpResponseWrapper<RouteDto>.Create(response);
    }
}