namespace perla_metro_main_api.src.Dto
{
    public class UpdateStationRequest
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Type { get; set; }
        public bool? IsActive { get; set; }

    }
}