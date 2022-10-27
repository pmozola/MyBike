using Bike.Shared.Domain;
using Bike.Shared.Domain.Exceptions;
using Bike.Wishlist.Domain.Wish;
using MediatR;

namespace Bike.Wishlist.Application.CommandHandlers;

public class DeleteWishCommandHandler : AsyncRequestHandler<DeleteWishCommand>
{
    private readonly IWishRepository wishRepository;
    private readonly IUserContext userContext;

    public DeleteWishCommandHandler(
        IWishRepository wishRepository,
        IUserContext userContext)
    {
        this.wishRepository = wishRepository;
        this.userContext = userContext;
    }

    protected override async Task Handle(DeleteWishCommand request, CancellationToken cancellationToken)
    {
        var entity = await wishRepository.GetAsync(request.Id, userContext.GetUserId(), cancellationToken);
        if (entity == null) throw new NotFoundDomainException();

        await wishRepository.DeleteAsync(entity, cancellationToken);
    }
}

public record DeleteWishCommand(int Id) : IRequest;