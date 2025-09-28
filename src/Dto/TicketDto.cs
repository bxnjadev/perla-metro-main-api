using System.Reflection.Metadata;

namespace perla_metro_main_api.Dto;

public class TicketDto
{
    public string Id { get; set; } = null!;
    public string PassengerId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Type { get; set; } = null!;
    public string Status { get; set; } = null!;
    public decimal Paid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}