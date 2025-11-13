using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billings.ReadAt;

public interface IReadAtBillingUseCase
{
    Task<ResponseBillingJson> Execute(long id);
}
