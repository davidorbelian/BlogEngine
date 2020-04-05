using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Comments;
using MediatR;
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
            var command = new CreateCommentCommand(body.Author, body.Content, articleId);
            var id = await _mediator.Send(command, ct);

            // TODO: Replace with Created(URI)
            return Ok(id);
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

        public sealed class PostBody
        {
            public string Author { get; set; }
            public string Content { get; set; }
        }
    }
}