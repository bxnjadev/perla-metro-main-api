namespace perla_metro_main_api.Dto;

public class EditTicket
{
    public DateTime? Date { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public decimal? Paid { get; set; }
}