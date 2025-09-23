namespace perla_metro_main_api.Dto;

public class RouteDto
{

    public string origin { get; set; }

    public string destination { get; set; }
    
    public string[] stops { get; set; }
    
    public string startTime { get; set; }
    
    public string endTime { get; set; }
    
}