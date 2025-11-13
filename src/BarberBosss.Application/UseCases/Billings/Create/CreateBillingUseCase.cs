using AutoMapper;
using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billings;

namespace BarberBoss.Application.UseCases.Billings.Create;

internal class CreateBillingUseCase : ICreateBillingUseCase
{
    private readonly IBillingsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBillingUseCase(
        IBillingsWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseBillingShortJson> Execute(RequestBillingJson request)
    {
        var validator = new BillingValidator();
        validator.Start(request);

        if (request.Status.Equals(PaymentStatus.Canceled)) request.Amount = 0;

        var entity = _mapper.Map<Billing>(request);

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseBillingShortJson>(entity);
    }
}
