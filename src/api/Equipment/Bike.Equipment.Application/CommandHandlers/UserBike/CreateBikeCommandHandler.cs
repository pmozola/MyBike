using Bike.Shared.Consts;
using FluentValidation;
using MediatR;

namespace Bike.Equipment.Application.CommandHandlers.UserBike
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, CreateBikeCommandResult>
    {
        public Task<CreateBikeCommandResult> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public record CreateBikeCommand(string Brand, string Model, DateOnly PurcharseDate, string FriendlyName) : IRequest<CreateBikeCommandResult>;

    public record CreateBikeCommandResult(int Id);

    public sealed class CreateBikeCommandValidator : AbstractValidator<CreateBikeCommand>
    {
        public CreateBikeCommandValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("")
                .WithErrorCode(ValidationErrorCodes.BikeBrandIsEmpty);
            RuleFor(x => x.Model)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("")
                .WithErrorCode(ValidationErrorCodes.BikeModelIsEmpty);
            RuleFor(x => x.PurcharseDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("")
                .WithErrorCode(ValidationErrorCodes.BikePurchaseDateIsMoreThanToday);
        }
    }
}
