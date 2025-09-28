namespace perla_metro_main_api.src.Dto
{
    public class CreateStationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Origen, Destino, Intermedio
        public bool IsActive { get; set; } = true;

    }
}