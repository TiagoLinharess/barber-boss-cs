using BarberBoss.Communication.Requests;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Billing;

internal class BillingValidator : AbstractValidator<RequestBillingJson>
{

    public BillingValidator()
    {
        RuleFor(billing => billing.Date).NotEmpty().WithMessage(ResourceErrorMessages.DATE_INVALID);

        RuleFor(billing => billing.BarberName)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.BARBER_NAME_REQUIRED)
            .Length(2, 80)
            .WithMessage(ResourceErrorMessages.BARBER_NAME_LENGTH_INVALID);

        RuleFor(billing => billing.ClientName)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.CLIENT_NAME_REQUIRED)
            .Length(2, 120)
            .WithMessage(ResourceErrorMessages.CLIENT_NAME_LENGTH_INVALID);

        RuleFor(billing => billing.Service).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_SERVICE);

        RuleFor(billing => billing.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

        RuleFor(billing => billing.PaymentMethod).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_METHOD);

        RuleFor(billing => billing.Status).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_STATUS);

        RuleFor(billing => billing.Notes)
            .MaximumLength(500)
            .WithMessage(ResourceErrorMessages.NOTES_LENGTH_INVALID)
            .When(notes => notes is not null);
    }

    public void Start(RequestBillingJson request)
    {
        var result = this.Validate(request);

        if (result.IsValid) return;

        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
        throw new ErrorOnValidationException(errorMessages);
    }
}
