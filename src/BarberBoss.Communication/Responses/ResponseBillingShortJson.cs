using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Responses;

public class ResponseBillingShortJson
{
    public long Id { get; set; }
    public string BarberName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public BarberService Service { get; set; }
}
