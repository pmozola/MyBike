using Bike.Shared.Domain;
using Bike.Wishlist.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Application.QueryHandlers;

public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, GetWishListCommandResult>
{
    private readonly WishlistDbContext dbContext;
    private readonly IUserContext userContext;

    public GetWishListQueryHandler(WishlistDbContext dbContext, IUserContext userContext)
    {
        this.dbContext = dbContext;
        this.userContext = userContext;
    }

    public async Task<GetWishListCommandResult> Handle(GetWishListQuery request, CancellationToken cancellationToken)
    {
        var wishes = await dbContext.Wish
            .Where(x => x.UserId == userContext.GetUserId())
            .Select(x => new WishResult(
                x.Id,
                x.Name,
                x.Description,
                x.Url,
                x.Category.ToString(),
                x.UserCategory == null ? 
                    null :
                    new UserCategoryResult(x.UserCategory.Id, x.UserCategory.Name )
                ))
            .ToListAsync(cancellationToken);

        return new GetWishListCommandResult(wishes);
    }
}

public record GetWishListQuery() : IRequest<GetWishListCommandResult>;
public record GetWishListCommandResult(IList<WishResult> Wishes) { public int TotalResult => Wishes.Count; };
public record WishResult(int Id, string Name, string Description, string Url, string CategoryName, UserCategoryResult? UserCategoryResult);
public record UserCategoryResult(int Id, string Name);