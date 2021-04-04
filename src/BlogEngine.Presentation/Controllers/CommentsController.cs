using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Comments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Presentation.Controllers
{
    [ApiController]
    [Route("api/articles/{articleId}/comments")]
    public sealed class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            string articleId,
            [FromBody] PostBody body,
            CancellationToken ct = default)
        {
            var (author, content) = body;
            var command = new CreateCommentCommand(author, content, articleId);
            var id = await _mediator.Send(command, ct);

            // TODO: Replace with Created(URI)
            return Ok(id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(
            string id,
            string articleId,
            CancellationToken ct = default)
        {
            var command = new DeleteCommentCommand(id, articleId);
            await _mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            string articleId,
            CancellationToken ct = default)
        {
            var query = new GetCommentsByArticleIdQuery(articleId);
            var comments = await _mediator.Send(query, ct);

            return Ok(comments);
        }

        public sealed record PostBody(string Author, string Content);
    }
}