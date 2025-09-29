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
    
    /// <summary>
    /// Create a new ticket from request DTO
    /// </summary>
    /// <param name="request">The request creation DTO</param>
    /// <returns>A object created</returns>
    
    [HttpPost("create")]
    [Authorize(Roles = "Admin")] 
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        

        var userId = User.FindFirst("Id")?.Value;
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("No se pudo obtener el ID del usuario del token.");
        }
        
        var response = await _ticketService.Create(request, userId, name);
        return StatusCode(response.GetStatusCode(), response.GetContent());

    }
    
    /// <summary>
    /// Find all tickets 
    /// </summary>
    /// <returns>A group tickets founded</returns>
    
    [HttpGet("findAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetTickets()
    {

        var response = await _ticketService.GetAll(true);
        return StatusCode(response.GetStatusCode(), response.GetContent());
    }

    /// <summary>
    /// Retrieve a ticket from id
    /// </summary>
    /// <param name="id">The ticket id</param>
    /// <returns>A ticket founded</returns>
    
    [HttpGet("find/{id}")]
    public async Task<ActionResult> GetTicketById(string id)
    {
        var response = await _ticketService.GetById(id);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
    /// <summary>
    /// Updated all ticket from id 
    /// </summary>
    /// <param name="id">the ticket id</param>
    /// <param name="request">a group parameters</param>
    /// <returns></returns>

    [HttpPatch("update/{id}")]
    public async Task<ActionResult> UpdateTicket(string id, [FromBody] EditTicket request)
    {
        var response =  await _ticketService.Update(id, request);

        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteTicket(string id, [FromQuery] bool admin = false)
    {

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
