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
        public async Task<IActionResult> Post(WishRequest request)
        {
            var result = await mediatr.Send(
                new CreateWishCommand(request.Name, request.Url, request.CategoryId, request.UserCategoryId, request.Description));

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

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetWishQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediatr.Send(new GetWishQuery(id));

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediatr.Send(new DeleteWishCommand(id));

            return Ok();
        }

        public class WishRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
            public int CategoryId { get; set; }
            public int? UserCategoryId { get; set; }
            public string? Description { get; set; } = string.Empty;
        }
    }
}