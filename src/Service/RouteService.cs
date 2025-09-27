using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public class RouteService(
    HttpClient httpClient,
    string route = Routes.RoutesRoute
) : IRouteService
{
    public async Task<HttpResponseWrapper<RouteDto>> Create(RouteDto routeDto)
    {
        var definitiveRoute = route + "/";

        // previamente verificar si las estaciones existen

        /*if ( estaciones existen){
            return new await HttpResponseWrapper<RouteDto>("Las estaciones no existen", 404);
        }*/

        var response = await httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(routeDto)
            .Build()
        );

        return await HttpResponseWrapper<RouteDto>.Create(response);
    }

    public Task<HttpResponseWrapper<RouteDto>> Search()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseWrapper<RouteDto>> Find(string uuid)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = httpClient.GetAsync(definitiveRoute);

        return await HttpResponseWrapper<RouteDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<RouteDto>> EditRoute(string uuid, EditRoute editRoute)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
            .ContentTypeJson()
            .Body(editRoute)
            .Build());
            
        return await HttpResponseWrapper<RouteDto>.Create(response);
    }

    public async Task<HttpResponseWrapper<RouteDto>> Delete(string uuid)
    {
        var definitiveRoute = route + "/" + uuid;
        var response = await httpClient.DeleteAsync(definitiveRoute);

        return await HttpResponseWrapper<RouteDto>.Create(response);
    }
}