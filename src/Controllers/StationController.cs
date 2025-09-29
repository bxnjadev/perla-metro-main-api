using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using perla_metro_main_api.src.Dto;
using perla_metro_main_api.Service;
using perla_metro_main_api.src.Util;

namespace perla_metro_main_api.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        
        /// <summary>
        /// Retrieve all stations from a query
        /// </summary>
        /// <param name="query">A group filters for query</param>
        /// <returns>A group stations</returns>

        // GET: api/station
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] StationQuery query)
        {
            var response = await _stationService.GetAll(query);
            var statusCode = response.GetStatusCode();
            var content = response.GetContent();

            return StatusCode(statusCode, content);
        }

        
        /// <summary>
        /// Find a station from id
        /// </summary>
        /// <param name="id">The id for found</param>
        /// <returns>A station founded</returns>
        
        // GET: api/station/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _stationService.GetById(id);
            var statusCode = response.GetStatusCode();
            var content = response.GetContent();

            return StatusCode(statusCode, content);
        }
        
        /// <summary>
        /// Create a new station from the request
        /// </summary>
        /// <param name="createStation">The create request DTO</param>
        /// <returns>The station created</returns>

        // POST: api/station
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStationRequest createStation)
        {
            var response = await _stationService.Create(createStation);
            var statusCode = response.GetStatusCode();
            var content = response.GetContent();

            return StatusCode(statusCode, content);
        }

        /// <summary>
        /// Update a data station from a group parameters
        /// </summary>
        /// <param name="id">The id station for update</param>
        /// <param name="updateStation">A group parameters from update</param>
        /// <returns>The entity updated</returns>
        
        // PUT: api/station/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStationRequest updateStation)
        {
            var response = await _stationService.Update(id, updateStation);
            var statusCode = response.GetStatusCode();
            var content = response.GetContent();

            return StatusCode(statusCode, content);
        }

        /// <summary>
        /// Delete a station from uuid 
        /// </summary>
        /// <param name="id">the id for delete</param>
        /// <returns>The entity station deleted</returns>
        
        // DELETE: api/station/{id}
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _stationService.Delete(id);
            var statusCode = response.GetStatusCode();
            var content = response.GetContent();

            return StatusCode(statusCode, content);
        }
    }
}