using System.Net;
using Bike.Wishlist.Application.CommandHandlers;
using Bike.Wishlist.Application.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bike.API.Controllers.Wishlist
{
    [ApiController]
    [Route("[controller]")]
    public class WishController : ControllerBase
    {
        private readonly ISender mediatr;

        public WishController(ISender mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(string name, string url, int categoryId, int? userCategoryId, string? description)
        {
            var result = await mediatr.Send(
                new CreateWishCommand(name, url, categoryId, userCategoryId, description));

            return Ok(result.Id);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await mediatr.Send(new GetWishListQuery());

            return Ok(result);
        }
    }
}