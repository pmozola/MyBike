using Bike.Shared.Consts;
using Bike.Shared.Domain;
using Bike.Wishlist.Domain.Wish;
using FluentValidation;
using MediatR;

namespace Bike.Wishlist.Application.CommandHandlers
{
    public class AddUserCategoryCommandHandler : IRequestHandler<AddUserCategoryCommand, AddUserCategoryCommandResult>
    {
        private readonly IUserCategoryRepository repository;
        private readonly IUserContext userContext;

        public AddUserCategoryCommandHandler(IUserCategoryRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }

        public async Task<AddUserCategoryCommandResult> Handle(AddUserCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = UserCategory.Create(userContext.GetUserId(), request.Name, request.CategoryId);

            await repository.AddAsync(category, cancellationToken);

            return new AddUserCategoryCommandResult(category.Id);
        }
    }

    public record AddUserCategoryCommand(string Name, int CategoryId) : IRequest<AddUserCategoryCommandResult>;

    public record AddUserCategoryCommandResult(int Id);

    public class AddUserCategoryValidator : AbstractValidator<AddUserCategoryCommand>
    {
        public AddUserCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be provided.")
                .WithErrorCode(ValidationErrorCodes.UserCategoryNameMustBeProvided);
        }
    }
}