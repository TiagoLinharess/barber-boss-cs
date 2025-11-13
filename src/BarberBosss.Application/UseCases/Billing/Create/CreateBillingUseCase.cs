using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Billing.Create;

internal class CreateBillingUseCase : ICreateBillingUseCase
{
    public async Task<ResponseBillingShortJson> Execute(RequestBillingJson request)
    {
        var validator = new BillingValidator();
        validator.Start(request);

        return await Task.FromResult(new ResponseBillingShortJson
        {
            Id = 7,
            BarberName = request.BarberName,
            ClientName = request.ClientName,
            Service = request.Service
        });
    }
}
