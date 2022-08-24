using Bike.Equipment.Database;
using Bike.Shared.Domain;
using Bike.Shared.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bike.Equipment.Application.QueryHandlers.UserBike;

public class GetUserBikeCommandHandler : IRequestHandler<GetUserBikeCommand, GetUserBikeResult>
{
    private readonly BikeEquipmentDbContext dbContext;
    private readonly IUserContext userContext;

    public GetUserBikeCommandHandler(BikeEquipmentDbContext dbContext, IUserContext userContext)
    {
        this.dbContext = dbContext;
        this.userContext = userContext;
    }

    public async Task<GetUserBikeResult> Handle(GetUserBikeCommand request, CancellationToken cancellationToken)
    {
        var userBikes = dbContext.Bike
            .Where(x => x.OwnerId == userContext.GetUserId())
            .Select(x => new GetUserBikeResult(x.Id, x.Model, x.Brand, x.FriendlyName, x.DistanceMeasures.Select(x => x.Value).Sum()));

        if (!await userBikes.AnyAsync(cancellationToken)) throw new NotFoundDomainException();

        return await userBikes.FirstAsync(cancellationToken);
    }
}

public record GetUserBikeCommand() : IRequest<GetUserBikeResult>;
public record GetUserBikeResult(int Id, string Model, string Brand, string? FriendlyName, double TotalDistance);
