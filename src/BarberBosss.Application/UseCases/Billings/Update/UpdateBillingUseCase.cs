using AutoMapper;
using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Requests;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billings.Update;

internal class UpdateBillingUseCase : IUpdateBillingUseCase
{
    private readonly IBillingsUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBillingUseCase(
        IBillingsUpdateOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(long id, RequestBillingJson request)
    {
        var validator = new BillingValidator();
        validator.Start(request);

        if (request.Status.Equals(PaymentStatus.Canceled)) request.Amount = 0;

        var billing = await _repository.ReadAt(id);

        if (billing is null) throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);

        _mapper.Map(request, billing);

        _repository.Update(billing);

        await _unitOfWork.Commit();
    }
}
