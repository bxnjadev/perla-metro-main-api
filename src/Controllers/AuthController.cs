using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    
        
    [HttpPost]
    [Route("/api/users/auth")]
    public async Task<ActionResult> Create(
        [FromBody] Credentials credentials
    )
    {
        var response = await authenticationService.Login(credentials);
        
        return StatusCode(response.GetStatusCode(), response.GetContent());
    }
    
}