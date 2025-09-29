using perla_metro_main_api.Dto;
using perla_metro_main_api.Util;
using System.Text.Json;

namespace perla_metro_main_api.Service;

public class TicketService : ITicketService
{
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;

    private static readonly string TicketBaseUrl = Routes.TicketsRoute;

    public TicketService(HttpClient httpClient, IUserService userService)
    {
        _httpClient = httpClient;
        _userService = userService;
    }

    public async Task<HttpResponseWrapper<TicketDto>> Create(CreateTicketRequest request, string? userId, string? userName)
    {
        try
        {
            Console.WriteLine(userName);
            Console.WriteLine(userId);
            var payload = new
            {

                passengerId = request.PassengerId,
                date = request.Date,
                type = request.Type,
                status = request.Status,
                paid = request.Paid,
            };
            var response = await _httpClient.PostAsJsonAsync($"{TicketBaseUrl}/create", payload);
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
            string adminParam = isAdmin.ToString().ToLower();
            string url = $"{TicketBaseUrl}/findAll?admin={adminParam}";

            var response = await _httpClient.GetAsync(url);
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
            var response = await _httpClient.GetAsync($"{TicketBaseUrl}/find/{id}");
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
            var response = await _httpClient.PatchAsJsonAsync($"{TicketBaseUrl}/update/{id}", payload);
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
            var response = await _httpClient.DeleteAsync($"{TicketBaseUrl}/delete/{id}?admin=true");
            return await HttpResponseWrapper<TicketDto>.Create(response);
        }
        catch (Exception ex)
        {
            return new HttpResponseWrapper<TicketDto>($"Error al eliminar el ticket: {ex.Message}", 500);
        }
    }
    
}