using Bike.Shared.Domain;
using Bike.Wishlist.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bike.Wishlist.Application.QueryHandlers;

public class GetUserCategoryQueryHandler : IRequestHandler<GetUserCategoryQuery, GetUserCategoryQueryResult>
{
    private readonly WishlistDbContext dbContext;
    private readonly IUserContext userContext;

    public GetUserCategoryQueryHandler(WishlistDbContext dbContext, IUserContext userContext)
    {
        this.dbContext = dbContext;
        this.userContext = userContext;
    }

    public async Task<GetUserCategoryQueryResult> Handle(GetUserCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await dbContext.UserCategories
            .Where(x => x.UserId == userContext.GetUserId())
            .Select(x => new GetUserCategoryResult(
                x.Id,
                x.Name,
                x.Category.Id))
            .ToListAsync(cancellationToken);

        return new GetUserCategoryQueryResult(categories);
    }
}

public record GetUserCategoryQuery() : IRequest<GetUserCategoryQueryResult>;
public record GetUserCategoryQueryResult(IList<GetUserCategoryResult> Categories) { public int TotalResult => Categories.Count; };
public record GetUserCategoryResult(int Id, string Name, int CategoryId);
