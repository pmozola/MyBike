using Bike.Shared.Consts;
using Bike.Shared.Domain;
using Bike.Wishlist.Domain.Wish;
using FluentValidation;
using MediatR;

namespace Bike.Wishlist.Application.CommandHandlers
{
    public class CreateWishCommandHandler : IRequestHandler<CreateWishCommand, CreateWishCommandResult>
    {
        private readonly IWishRepository wishRepository;
        private readonly IUserContext userContext;

        public CreateWishCommandHandler(IWishRepository wishRepository, IUserContext userContext)
        {
            this.wishRepository = wishRepository;
            this.userContext = userContext;
        }
        public async Task<CreateWishCommandResult> Handle(CreateWishCommand request, CancellationToken cancellationToken)
        {
            var wish = WishAggregate.CreateWish(userContext.GetUserId(), request.Name, request.Url, request.CategoryId, request.Description);
            await this.wishRepository.AddAsync(wish, cancellationToken);

            return new CreateWishCommandResult(wish.Id);
        }
    }

    public record CreateWishCommand(string Name, string Url, int CategoryId, string? Description) : IRequest<CreateWishCommandResult>;

    public record CreateWishCommandResult(int Id);

    public class CreateWishCommandHandlerValidator : AbstractValidator<CreateWishCommand>
    {
        public CreateWishCommandHandlerValidator()
        {
            RuleFor(x => x.Url)
                 .NotEmpty()
                 .WithMessage("Url must be provided.")
                 .WithErrorCode(ValidationErrorCodes.UrlMustBeProvided);
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("CategoryId must be provided.")
                .WithErrorCode(ValidationErrorCodes.WishCategoryIdMustBeProvided);
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be provided.")
                .WithErrorCode(ValidationErrorCodes.WishNameMustBeProvided);
        }
    }
}
