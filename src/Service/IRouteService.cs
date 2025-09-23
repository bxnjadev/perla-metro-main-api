using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public interface IRouteService
{

    Task<HttpResponseWrapper<RouteDto>> Create(RouteDto routeDto);

    Task<HttpResponseWrapper<RouteDto>> Search();

    Task<HttpResponseWrapper<RouteDto>> Find(int id);

    Task<HttpResponseWrapper<RouteDto>> EditRoute(int id, EditRoute editRoute);
    
    Task<HttpResponseWrapper<RouteDto>> Delete(int id);
    
}