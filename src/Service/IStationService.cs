using perla_metro_main_api.src.Dto;
using perla_metro_main_api.src.Util;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service
{
    public interface IStationService
    {
        Task<HttpResponseWrapper<GetStationResponse>> GetAll(StationQuery query);
        Task<HttpResponseWrapper<GetStationResponse>> GetById(Guid id);
        Task<HttpResponseWrapper<GetStationResponse>> Create(CreateStationRequest createStation);
        Task<HttpResponseWrapper<GetStationResponse>> Update(Guid id, UpdateStationRequest updateStation);
        Task<HttpResponseWrapper<bool>> Delete(Guid id);
    }
}
