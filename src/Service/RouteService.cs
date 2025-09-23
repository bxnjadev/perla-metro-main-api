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

        // previamente verificar si las rutas existen

        /*if ( rutas existen){
            return new await HttpResponseWrapper<RouteDto>("Las rutas no existen", 404);
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

    public Task<HttpResponseWrapper<RouteDto>> Find(int id)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseWrapper<RouteDto>> EditRoute(int id, EditRoute editRoute)
    { 
        throw new NotImplementedException();
    }

    public Task<HttpResponseWrapper<RouteDto>> Delete(int id)
    {
        throw new NotImplementedException();
    }
}