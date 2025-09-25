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

    private const string TicketsServiceUrl = "http://localhost:5050/tickets";

    public TicketsController(HttpClient httpClient, IUserService userService)
    {
        _httpClient = httpClient;
        _userService = userService;
    }

    [HttpPost]
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

    [HttpGet]
    public async Task<ActionResult> GetTickets([FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }

        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}?admin={admin}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTicketById(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/{id}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateTicket(string id, [FromBody] UpdateTicketRequest request)
    {
        var ticketPayload= new
        {
            date = request.Date,
            type = request.Type,
            status = request.Status,
            paid = request.Paid
        };

        var response = await _httpClient.PatchAsJsonAsync($"{TicketsServiceUrl}/{id}", ticketPayload);
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTicket(string id, [FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }
        var response = await _httpClient.DeleteAsync($"{TicketsServiceUrl}/{id}?admin={admin}");
        var content = await response.Content.ReadAsStringAsync();

        return StatusCode((int)response.StatusCode, content);
    }
}
