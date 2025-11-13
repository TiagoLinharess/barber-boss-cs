using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billings.Create;

public interface ICreateBillingUseCase
{
    public Task<ResponseBillingShortJson> Execute(RequestBillingJson request);
}
