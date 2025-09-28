using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.Util;
using System.Security.Claims;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;
    private readonly ITicketService _ticketService;

    private readonly string TicketsServiceUrl = Routes.TicketsRoute;

    public TicketsController(HttpClient httpClient, IUserService userService,
        ITicketService ticketService)
    {
        _httpClient = httpClient;
        _userService = userService;
        _ticketService = ticketService;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        var userId = User.FindFirst("id")?.Value;
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        var response = await _ticketService.Create(request, userId, name);
        return StatusCode(response.GetStatusCode(),response.GetContent());

    }

    [HttpGet("findAll")]
    [Authorize]
    public async Task<ActionResult> GetTickets([FromQuery] bool admin = false)
    {
        var userRole = User.FindFirst("role")?.Value ?? User.FindFirst(ClaimTypes.Role)?.Value;
        var isAdmin = userRole?.ToLower() == "admin"|| User.IsInRole("admin");

        if (!admin || !isAdmin)
        {
            return Forbid("Acceso denegado. Solo los administradores pueden ver todos los tickets");
        }

        var response = await _ticketService.GetAll(admin);
        return StatusCode(response.GetStatusCode(), response.GetContent());
    }

    [HttpGet("find/{id}")]
    public async Task<ActionResult> GetTicketById(string id)
    {
        var response = await _ticketService.GetById(id);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }

    [HttpPatch("update/{id}")]
    public async Task<ActionResult> UpdateTicket(string id, [FromBody] EditTicket request)
    {
        var response =  await _ticketService.Update(id, request);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
    [HttpDelete("delete/{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteTicket(string id, [FromQuery] bool admin = false)
    {
        var userRole = User.FindFirst("role")?.Value ?? User.FindFirst(ClaimTypes.Role)?.Value;
        var isAdmin = userRole?.ToLower() == "admin" || User.IsInRole("admin");

        if (!admin || !isAdmin)
        {
            return Forbid ("El parámetro 'admin' debe ser true para acceder a esta ruta.");
        }

        var response = await _ticketService.SoftDelete(id);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }

    [HttpGet("create")]
    public async Task<ActionResult> CreateTicketInfo()
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/crear");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }

    [HttpGet("update/{id}")]
    public async Task<ActionResult> GetTicketByIdInfo(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/actualizar/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }

    [HttpGet("delete/{id}")]
    public async Task<ActionResult> DeleteTicketInfo(string id)
    {
        var response = await _httpClient.GetAsync($"{TicketsServiceUrl}/eliminar/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return StatusCode((int)response.StatusCode, content);
    }
    
}
