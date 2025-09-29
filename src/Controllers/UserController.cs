using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.Util;

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

        return StatusCode(statusCode, content);
    }
    
    [HttpGet]
    [Authorize]
    [Route("/api/users/find/{uuid}")]
    public async Task<ActionResult<UserDto>> Find(
        string uuid)
    {
        var response = await userService.Find(uuid);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }
    
    [HttpDelete]
    [Authorize]
    [Route("/api/users/delete/{uuid}")]
    public async Task<ActionResult<UserDto>> Delete(
        string uuid
    )
    {

        var response = await userService.Delete(uuid);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }
    
    [HttpPut]
    [Authorize]
    [Route("/api/users/edit/{uuid}")]
    public async Task<ActionResult<UserDto>> Edit(
        string uuid,
        [FromBody] EditUser editUser
    )
    {

        var response = await userService.Edit(uuid, editUser);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }

    [HttpGet]
    [Authorize]
    [Route("/api/users/search")]
    public async Task<ActionResult<ICollection<UserDto>>> Search(
        [FromQuery] string? name,
        [FromQuery] string? email,
        [FromQuery] bool? searchByIsActive
    )
    {
        var url = HttpContext.Request.GetDisplayUrl();
        var sections = url.Split("?");

        HttpResponseWrapper<ICollection<UserDto>> response;
        if (sections.Length == 1)
        {
            Console.WriteLine("helllo world");
            response = await userService.Search("");
        }
        else
        {
            response = await userService.Search(sections[1]);    
        }
        
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();
        return StatusCode(statusCode, content);
    }

    
}