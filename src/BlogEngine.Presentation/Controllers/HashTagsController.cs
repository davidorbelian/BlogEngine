using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Articles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Presentation.Controllers
{
    [ApiController]
    [Route("api/hashtags")]
    public sealed class HashTagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HashTagsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{hashTag}/articles")]
        public async Task<IActionResult> Get(
            string hashTag,
            CancellationToken ct = default)
        {
            var query = new GetArticlesByHashTagQuery(hashTag);
            var articles = await _mediator.Send(query, ct);

            return Ok(articles);
        }
    }
}