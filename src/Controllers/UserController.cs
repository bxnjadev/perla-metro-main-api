using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    
    [HttpPost]
    [Route("/api/users/create")]
    public async Task<ActionResult> Create(
        [FromBody] CreationUserRequest creationUser
    )
    {
        var response = await userService.Create(creationUser);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();
        
        return StatusCode(statusCode, 
            content);
    }

    
}