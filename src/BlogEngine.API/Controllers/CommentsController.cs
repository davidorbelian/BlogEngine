using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.Application.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [Route("api/articles/{articleId}/comments")]
    public sealed class CommentsController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            string articleId,
            [FromBody] CommentPostBody body,
            CancellationToken ct = default)
        {
            var command = new CreateCommentCommand(body.Author, body.Content, articleId);
            var id = await Mediator.Send(command, ct);

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
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            string articleId,
            CancellationToken ct = default)
        {
            var query = new GetCommentsByArticleIdQuery(articleId);
            var comments = await Mediator.Send(query, ct);

            return Ok(comments);
        }

        public sealed record CommentPostBody(string Author, string Content);
    }
}