using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;

    private const string TicketsServiceUrl = "https://perla-metro-tickets.onrender.com/api/tickets";

    public TicketsController(HttpClient httpClient, IUserService userService)
    {
        _httpClient = httpClient;
        _userService = userService;
    }

    [HttpPost("crear")]
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        var userResponse = await _userService.Find(request.PassengerId);
        if (userResponse.GetStatusCode() != 200)
        {
            return BadRequest("El usuario especificado no existe");
        }
        var ticketPayload = new
        {
            passengerId = request.PassengerId,
            date = request.Date,
            type = request.Type,
            status = request.Status,
            paid = request.Paid
        };

        var response = await _httpClient.PostAsJsonAsync(TicketsServiceUrl, ticketPayload);
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);

    }

    [HttpGet("obtener")]
    public async Task<ActionResult> GetTickets([FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }

        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}?admin={admin.ToString().ToLower()}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
    [HttpGet("buscar/{id}")]
    public async Task<ActionResult> GetTicketById(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/buscar/{id}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }

    [HttpPatch("actualizar/{id}")]
    public async Task<ActionResult> UpdateTicket(string id, [FromBody] EditTicket request)
    {
        var ticketPayload = new
        {
            date = request.Date,
            type = request.Type,
            status = request.Status,
            paid = request.Paid
        };

        var response = await _httpClient.PatchAsJsonAsync($"{TicketsServiceUrl}/actualizar/{id}", ticketPayload);
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
    [HttpDelete("eliminar/{id}")]
    public async Task<ActionResult> DeleteTicket(string id, [FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }
        var response = await _httpClient.DeleteAsync($"{TicketsServiceUrl}/eliminar/{id}?admin={admin.ToString().ToLower()}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }

    [HttpGet("crear")]
    public async Task<ActionResult> CreateTicketInfo()
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/crear");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }

    [HttpGet("actualizar/{id}")]
    public async Task<ActionResult> GetTicketByIdInfo(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/actualizar/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }

    [HttpGet("eliminar/{id}")]
    public async Task<ActionResult> DeleteTicketInfo(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/eliminar/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }
    
}
