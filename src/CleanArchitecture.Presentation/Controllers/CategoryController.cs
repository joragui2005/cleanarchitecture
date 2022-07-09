using System.Net;
using CleanArchitecture.Application.Features.Category.Commands.Create;
using CleanArchitecture.Application.Features.Category.Commands.Delete;
using CleanArchitecture.Application.Features.Category.Commands.Update;
using CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "GetCategories")]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var query = new GetCategoriesListQuery();
            var items = await _mediator.Send(query);

            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GeGetCategoryById(int id)
        {
            var query = new GetCategoriesListQuery(id);
            var categories = await _mediator.Send(query);

            return Ok(categories);
        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateItem([FromBody] CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
