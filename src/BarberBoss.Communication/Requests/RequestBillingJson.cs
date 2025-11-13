using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Requests;

public class RequestBillingJson
{
    public DateOnly Date { get; set; }
    public string BarberName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public BarberService Service { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string? Notes { get; set; } = string.Empty;
}
