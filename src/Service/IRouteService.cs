using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public interface IRouteService
{

    Task<HttpResponseWrapper<CreationRouteRequest>> Create(CreationRouteRequest creationRoute);

    Task<HttpResponseWrapper<CreationRouteRequest>> GetAll();
    Task<HttpResponseWrapper<CreationRouteRequest>> Find(string id);

    Task<HttpResponseWrapper<EditRoute>> EditRoute(string id, EditRoute editRoute);
    
    Task<HttpResponseWrapper<RouteDto>> Delete(string id);
    
}