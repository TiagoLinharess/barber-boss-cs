using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Billings;

namespace BarberBoss.Application.UseCases.Billings.Read;

internal class ReadBillingUseCase : IReadBillingUseCase
{
    private readonly IBillingsReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public ReadBillingUseCase(
        IBillingsReadOnlyRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResponseBillingShortJson>> Execute()
    {
        var expenses = await _repository.Read();
        return _mapper.Map<List<ResponseBillingShortJson>>(expenses);
    }
}
