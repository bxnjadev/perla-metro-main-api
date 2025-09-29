namespace perla_metro_main_api.Dto;

public class RouteDto
{
    public string originId { get; set; }
    public string destinationId { get; set; }

    public string[] stopsIds { get; set; }

    public string startTime { get; set; }

    public string endTime { get; set; }
    
    public string isActive { get; set; }
    
}