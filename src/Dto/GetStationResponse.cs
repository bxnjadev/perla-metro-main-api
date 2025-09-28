namespace perla_metro_main_api.src.Dto
{
    public class GetStationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}