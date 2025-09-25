using System.ComponentModel.DataAnnotations;

namespace perla_metro_main_api.Dto;
public class CreateTicketRequest
{
    [Required]
    public string PassengerId { get; set; } = null!;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
    public decimal Paid { get; set; }
}