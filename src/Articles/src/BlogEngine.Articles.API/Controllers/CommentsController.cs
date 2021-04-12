using System;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.API.Core.Attributes;
using BlogEngine.Articles.Application.Requests.Comments.Commands;
using BlogEngine.Articles.Application.Requests.Comments.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Articles.API.Controllers
{
    [ApiRoute("articles/{articleId}/comments")]
    public sealed class CommentsController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromRoute] Guid articleId,
            [FromBody] CommentPostBody body,
            CancellationToken ct = default)
        {
            var command = new CreateCommentCommand(body.Author, body.Content, articleId);
            var comment = await Mediator.Send(command, ct);

            return Created($"api/articles/{articleId}/comments/{comment.Id}", comment);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromRoute] Guid articleId,
            CancellationToken ct = default)
        {
            var command = new DeleteCommentCommand(id, articleId);
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id,
            [FromRoute] Guid articleId,
            CancellationToken ct = default)
        {
            var query = new GetCommentByIdAndArticleIdQuery(id, articleId);
            var comment = await Mediator.Send(query, ct);

            return Ok(comment);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute] Guid articleId,
            CancellationToken ct = default)
        {
            var query = new GetCommentsByArticleIdQuery(articleId);
            var comments = await Mediator.Send(query, ct);

            return Ok(comments);
        }

        public sealed record CommentPostBody(string Author, string Content);
    }
}