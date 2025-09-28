using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public interface IAuthenticationService
{

    Task<HttpResponseWrapper<string>> Login(Credentials credentials);

}
