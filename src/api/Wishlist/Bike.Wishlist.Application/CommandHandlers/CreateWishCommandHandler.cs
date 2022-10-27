using Bike.Shared.Consts;
using Bike.Shared.Domain;
using Bike.Shared.Domain.Exceptions;
using Bike.Wishlist.Domain.Wish;
using FluentValidation;
using MediatR;

namespace Bike.Wishlist.Application.CommandHandlers
{
    public class CreateWishCommandHandler : IRequestHandler<CreateWishCommand, CreateWishCommandResult>
    {
        private readonly IWishRepository wishRepository;
        private readonly IUserCategoryRepository userCategoryRepository;
        private readonly IUserContext userContext;

        public CreateWishCommandHandler(
            IWishRepository wishRepository,
            IUserCategoryRepository userCategoryRepository,
            IUserContext userContext)
        {
            this.wishRepository = wishRepository;
            this.userCategoryRepository = userCategoryRepository;
            this.userContext = userContext;
        }
        public async Task<CreateWishCommandResult> Handle(CreateWishCommand request, CancellationToken cancellationToken)
        {
            UserCategory? userCategory = null;
            
            if (request.UserCategoryId.HasValue)
            {
                userCategory = await userCategoryRepository.GetAsync(userContext.GetUserId(), request.UserCategoryId.Value, cancellationToken);
                if (userCategory == null) throw new NotFoundDomainException();
            }

            var wish = WishAggregate.CreateWish(userContext.GetUserId(), request.Name, request.Url, request.CategoryId, userCategory, request.Description);
            await this.wishRepository.AddAsync(wish, cancellationToken);

            return new CreateWishCommandResult(wish.Id);
        }
    }

    public record CreateWishCommand(string Name, string Url, int CategoryId, int? UserCategoryId, string? Description) : IRequest<CreateWishCommandResult>;

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
