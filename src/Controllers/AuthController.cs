using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    
        
    /// <summary>
    /// HTTP Method for authenticate with system
    /// </summary>
    /// <param name="credentials">A group credentials</param>
    /// <returns>A response with data JWT</returns>
    
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] Credentials credentials
    )
    {
        var response = await authenticationService.Login(credentials);
        
        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
}