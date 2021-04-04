using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Articles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Presentation.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public sealed class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(
            [FromBody] PostBody body,
            CancellationToken ct = default)
        {
            var (title, content) = body;
            var command = new CreateArticleCommand(title, content);
            var id = await _mediator.Send(command, ct);

            // TODO: Replace with Created(URI)
            return Ok(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(
            string id,
            [FromBody] PutBody body,
            CancellationToken ct = default)
        {
            var (title, content) = body;
            var command = new UpdateArticleCommand(id, title, content);
            var newId = await _mediator.Send(command, ct);

            // TODO: Replace newId with URI
            return Ok(newId);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(
            string id,
            CancellationToken ct = default)
        {
            var command = new DeleteArticleCommand(id);
            await _mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            string id,
            CancellationToken ct = default)
        {
            var query = new GetArticleByIdQuery(id);
            var article = await _mediator.Send(query, ct);

            return Ok(article);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken ct = default)
        {
            var query = new GetArticlesQuery();
            var articles = await _mediator.Send(query, ct);

            return Ok(articles);
        }

        public sealed record PostBody(string Title, string Content);
        public sealed record PutBody(string Title, string Content);
    }
}