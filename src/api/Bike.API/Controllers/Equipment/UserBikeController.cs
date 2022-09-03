using System.Net;
using Bike.Equipment.Application.CommandHandlers.UserBike;
using Bike.Equipment.Application.QueryHandlers.UserBike;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bike.API.Controllers.Equipment
{
    [ApiController]
    [Route("[controller]")]
    public class UserBikeController : ControllerBase
    {
        private readonly ISender mediatr;

        public UserBikeController(ISender mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(string brand, string model, DateTime purcharseDate, string? friendlyName)
        {
            var result = await mediatr.Send(
                new CreateBikeCommand(brand, model, DateOnly.FromDateTime(purcharseDate), friendlyName));

            return Ok(result.Id);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await mediatr.Send(new GetUserBikeCommand());

            return Ok(result);
        }
    }
}