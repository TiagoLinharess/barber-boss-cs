using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billing.Create;

public interface ICreateBillingUseCase
{
    public Task<ResponseBillingShortJson> Execute(RequestBillingJson request);
}
