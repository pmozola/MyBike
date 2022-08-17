using Bike.Equipment.Domain.Bike;
using Bike.Shared.Consts;
using Bike.Shared.Domain;
using FluentValidation;
using MediatR;

namespace Bike.Equipment.Application.CommandHandlers.UserBike
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, CreateBikeCommandResult>
    {
        private readonly IUserContext userContext;
        private readonly IBikeRepository bikeRepository;

        public CreateBikeCommandHandler(IUserContext userContext, IBikeRepository bikeRepository)
        {
            this.userContext = userContext;
            this.bikeRepository = bikeRepository;
        }

        public async Task<CreateBikeCommandResult> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = BikeAggregate.CreateNewBike(request.Brand, request.Model, request.PurcharseDate, userContext.GetUserId());

            await bikeRepository.AddAsync(bike, cancellationToken);

            return new CreateBikeCommandResult(bike.Id);
        }
    }

    public record CreateBikeCommand(string Brand, string Model, DateOnly PurcharseDate, string? FriendlyName) : IRequest<CreateBikeCommandResult>;

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
