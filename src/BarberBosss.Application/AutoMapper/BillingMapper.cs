using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper;

internal class BillingMapper : Profile
{
    public BillingMapper()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestBillingJson, Billing>();
    }

    private void EntityToResponse()
    {
        CreateMap<Billing, ResponseBillingShortJson>();
        CreateMap<Billing, ResponseBillingJson>();
    }
}
