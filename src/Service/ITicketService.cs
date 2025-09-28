using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Service;

public interface ITicketService
{
    Task<HttpResponseWrapper<TicketDto>> Create(CreateTicketRequest createTicketRequest);
    Task<HttpResponseWrapper<TicketDto>> GetAll(bool isAdmin);

    Task<HttpResponseWrapper<TicketDto>> GetById(string id);

    Task<HttpResponseWrapper<TicketDto>> Update(string id, EditTicket request);

    Task<HttpResponseWrapper<TicketDto>> SoftDelete(string id);
}