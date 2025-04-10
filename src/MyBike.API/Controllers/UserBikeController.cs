using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBike.Application.Handlers.Queries.Bike.GetUserBike;

namespace MyBike.API.Controllers;

[ApiController]
[Route("user/bike")]
public class UserBikeController(ISender sender) : ControllerBase
{
    [HttpGet]
    public Task<GetUserQueryResponse> GetUserBike()
    {
        return sender.Send(new GetUserQuery());
    }
}