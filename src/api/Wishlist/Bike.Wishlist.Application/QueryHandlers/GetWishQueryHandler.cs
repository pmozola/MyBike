using Bike.Shared.Domain;
using Bike.Shared.Domain.Exceptions;
using Bike.Wishlist.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Application.QueryHandlers;

public class GetWishQueryHandler : IRequestHandler<GetWishQuery, GetWishQueryResponse>
{
    private readonly WishlistDbContext dbContext;
    private readonly IUserContext userContext;

    public GetWishQueryHandler(WishlistDbContext dbContext, IUserContext userContext)
    {
        this.dbContext = dbContext;
        this.userContext = userContext;
    }

    public async Task<GetWishQueryResponse> Handle(GetWishQuery request, CancellationToken cancellationToken)
    {
        var result = await this.dbContext.Wish
            .FirstOrDefaultAsync(
                wish => wish.Id == request.Id && wish.UserId == userContext.GetUserId(),
                cancellationToken: cancellationToken);

        if (result == null) throw new NotFoundDomainException();

        return new GetWishQueryResponse(
            result.Id,
            result.Name,
            result.Description,
            result.Url,
            result.Category.ToString(),
            result.UserCategory == null ? string.Empty : result.UserCategory.Name);
    }
}

public record GetWishQuery(int Id) : IRequest<GetWishQueryResponse>;

public record GetWishQueryResponse(int Id, string Name, string Description, string Url, string CategoryName, string UserCategoryName);
