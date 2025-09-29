using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.Util;

namespace perla_metro_main_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RouteController(IRouteService routeService) : ControllerBase
{
    [HttpPost]
    [Route("/api/routes/create")]
    public async Task<ActionResult> Create(
        [FromBody] CreationRouteRequest creationRoute
    )
    {
        var response = await routeService.Create(creationRoute);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("/api/routes/find/{id}")]
    public async Task<IActionResult> Find(string id)
    {
        var response = await routeService.Find(id);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }

    [HttpPut]
    [Route("/api/routes/edit/{uuid}")]
    public async Task<IActionResult> Edit(string uuid, [FromBody] EditRoute editRoute)
    {
        var response = await routeService.EditRoute(uuid, editRoute);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("/api/routes/all")]
    public async Task<IActionResult> GetAllRoutes()
    {
        var response = await routeService.GetAll();
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("/api/routes/delete/{id}")]
    public async Task<IActionResult> DeleteRoute(string id)
    {
        var response = await routeService.Delete(id);
        var statusCode = response.GetStatusCode();
        var content = response.GetContent();

        return StatusCode(statusCode, content);
    }


}