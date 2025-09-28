using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.src.Dto;
using perla_metro_main_api.src.Util;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.src.Service
{
    public class StationService : IStationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _route;

        public StationService(HttpClient httpClient, string? route = null)
        {
            _httpClient = httpClient;
            _route = route ?? Routes.StationsRoute;
        }
        public async Task<HttpResponseWrapper<GetStationResponse>> GetAll(StationQuery query)
        {
            var definitiveRoute = _route + $"?PageNumber={query.PageNumber}&PageSize={query.PageSize}";

            if (!string.IsNullOrWhiteSpace(query.SortBy))
                definitiveRoute += $"&SortBy={query.SortBy}&IsDescending={query.IsDescending}";

            var response = await _httpClient.GetAsync(definitiveRoute);

            return await HttpResponseWrapper<GetStationResponse>.Create(response);
        }

        public async Task<HttpResponseWrapper<GetStationResponse>> GetById(Guid id)
        {
            var definitiveRoute = _route + "/" + id;
            var response = await _httpClient.GetAsync(definitiveRoute);

            return await HttpResponseWrapper<GetStationResponse>.Create(response);
        }

        public async Task<HttpResponseWrapper<GetStationResponse>> Create(CreateStationRequest createStation)
        {
            var definitiveRoute = _route + "/";
            var response = await _httpClient.PostAsync(definitiveRoute, StringContentBuilder.Builder()
                .ContentTypeJson()
                .Body(createStation)
                .Build()
            );

            return await HttpResponseWrapper<GetStationResponse>.Create(response);
        }

        public async Task<HttpResponseWrapper<GetStationResponse>> Update(Guid id, UpdateStationRequest updateStation)
        {
            var definitiveRoute = _route + "/" + id;
            var response = await _httpClient.PutAsync(definitiveRoute, StringContentBuilder.Builder()
                .ContentTypeJson()
                .Body(updateStation)
                .Build()
            );

            return await HttpResponseWrapper<GetStationResponse>.Create(response);
        }

        public async Task<HttpResponseWrapper<bool>> Delete(Guid id)
        {
            var definitiveRoute = _route + "/" + id;
            var response = await _httpClient.DeleteAsync(definitiveRoute);

            return await HttpResponseWrapper<bool>.Create(response);
        }

    }

}