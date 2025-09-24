using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TicketsController(ITicketService ticketService) : ControllerBase

