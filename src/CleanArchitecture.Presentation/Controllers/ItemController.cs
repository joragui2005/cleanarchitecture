using System.Net;
using CleanArchitecture.Application.Features.Item.Commands.Create;
using CleanArchitecture.Application.Features.Item.Commands.Delete;
using CleanArchitecture.Application.Features.Item.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateItem([FromBody] CreateItemCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var command = new DeleteItemCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
