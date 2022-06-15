using System.Net;
using CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[cotroller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GeGetCategoryByIdt(int id)
        {
            var query = new GetCategoriesListQuery(id);
            var categories = await _mediator.Send(query);

            return Ok(categories);
        }
    }
}
