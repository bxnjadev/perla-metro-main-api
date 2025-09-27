namespace perla_metro_main_api.Service;

// Definir los elementos a editar

public class EditRoute
{
    public string origin { get; set; }
    
    public string destination { get; set; }
    
    public string[] stops { get; set; }
    
    public string startTime { get; set; }
    
    public string endTime { get; set; }
}