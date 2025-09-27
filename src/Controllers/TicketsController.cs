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
    private readonly ITicketService _ticketService;

    private const string TicketsServiceUrl = "https://perla-metro-tickets.onrender.com/api/tickets";

    public TicketsController(HttpClient httpClient, IUserService userService,
        ITicketService ticketService)
    {
        _httpClient = httpClient;
        _userService = userService;
        _ticketService = ticketService;
    }

    [HttpPost("crear")]
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        var userResponse = await _userService.Find(request.PassengerId);
        if (userResponse.GetStatusCode() != 200)
        {
            return BadRequest("El usuario especificado no existe");
        }

        var response = await _ticketService.Create(request);
        return StatusCode(response.GetStatusCode(),response.GetContent());

    }

    [HttpGet("obtener")]
    public async Task<ActionResult> GetTickets([FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }

        var response = await _ticketService.GetAll(admin);
        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
    [HttpGet("buscar/{id}")]
    public async Task<ActionResult> GetTicketById(string id)
    {
        var response = await _ticketService.GetById(id);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }

    [HttpPatch("actualizar/{id}")]
    public async Task<ActionResult> UpdateTicket(string id, [FromBody] EditTicket request)
    {
        var response =  await _ticketService.Update(id, request);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    [HttpDelete("eliminar/{id}")]
    public async Task<ActionResult> DeleteTicket(string id, [FromQuery] bool admin = false)
    {
        if (!admin)
        {
            return BadRequest("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }

        var response = await _ticketService.SoftDelete(id);

        return StatusCode(response.GetStatusCode(), response.GetContent());
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
