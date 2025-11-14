using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billings.Read;

public interface IReadBillingUseCase
{
    Task<List<ResponseBillingShortJson>> Execute();
}
