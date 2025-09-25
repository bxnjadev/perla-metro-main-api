using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;
using System.Text.Json;

namespace perla_metro_main_api.Service;

public class TicketService : ITicketService
{
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;

    private const string TicketBaseUrl = Routes.TicketRoute;

    public TicketService(HttpClient httpClient, IUserService userService)
    {
        _httpClient = httpClient;
        _userService = userService;
    }

    public async Task<HttpResponseWrapper<TicketDto>> Create(CreateTicketRequest request)
    {
        try
        {
            var userResponse = await _userService.Find(request.PassengerId);
            if (userResponse.GetStatusCode() != 200)
            {
                return new HttpResponseWrapper<TicketDto>("El usuario especificado no existe", 404);
            }
            var payload = new
            {
                passengerId = request.PassengerId,
                date = request.Date,
                type = request.Type,
                status = request.Status,
                paid = request.Paid
            };
            var response = await _httpClient.PostAsJsonAsync(TicketBaseUrl, payload);
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al crear el ticket: {ex.Message}", 500);
        }
    }

    public async Task<HttpResponseWrapper<TicketDto>> GetAll(bool isAdmin)
    {
        try
        {
            if (!isAdmin)
            {
                return new HttpResponseWrapper<TicketDto>("Acceso denegado. Solo los administradores pueden ver todos los tickets", 403);
            }
            var response = await _httpClient.GetAsync($"{TicketBaseUrl}?admin={isAdmin}");
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al obtener los tickets: {ex.Message}", 500);
        }
    }

    public async Task<HttpResponseWrapper<TicketDto>> GetById(string id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{TicketBaseUrl}/{id}");
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al obtener el ticket: {ex.Message}", 500);
        }
    }

    public async Task<HttpResponseWrapper<TicketDto>> Update(string id, EditTicket request)
    {
        try
        {
            var payload = new
            {
                date = request.Date,
                type = request.Type,
                status = request.Status,
                paid = request.Paid
            };
            var response = await _httpClient.PatchAsJsonAsync($"{TicketBaseUrl}/{id}", payload);
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al actualizar el ticket: {ex.Message}", 500);
        }
    }

    public async Task<HttpResponseWrapper<TicketDto>> SoftDelete(string id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{TicketBaseUrl}/{id}?admin=true");
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al eliminar el ticket: {ex.Message}", 500);
        }
    }
    
}