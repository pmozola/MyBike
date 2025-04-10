using MediatR;

namespace MyBike.Application.Handlers.Queries.Bike.GetUserBike;

public class GetUserBikeQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
{
    public Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetUserQueryResponse("Canyon"));
    }
}

public record GetUserQuery : IRequest<GetUserQueryResponse>;

public record GetUserQueryResponse(string Name);