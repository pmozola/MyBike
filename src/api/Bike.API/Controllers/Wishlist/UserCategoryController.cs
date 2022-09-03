using System.Net;
using Bike.Wishlist.Application.CommandHandlers;
using Bike.Wishlist.Application.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bike.API.Controllers.Wishlist
{
    [ApiController]
    [Route("[controller]")]
    public class UserCategoryController : ControllerBase
    {
        private readonly ISender mediatr;

        public UserCategoryController(ISender mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(string name, int categoryId)
        {
            var result = await this.mediatr.Send(
                new AddUserCategoryCommand(name, categoryId));

            return Ok(result.Id);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediatr.Send(new GetUserCategoryQuery());

            return Ok(result);
        }
    }
}