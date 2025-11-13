using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billings.ReadAt;

internal class ReadAtBillingUseCase : IReadAtBillingUseCase
{
    private readonly IBillingsReadOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReadAtBillingUseCase(
        IBillingsReadOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseBillingJson> Execute(long id)
    {
        var entity = await _repository.ReadAt(id);

        return entity is null
            ? throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND)
            : _mapper.Map<ResponseBillingJson>(entity);
    }
}
