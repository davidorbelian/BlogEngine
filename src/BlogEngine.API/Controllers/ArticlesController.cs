﻿using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.Application.Requests.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [Route("api/articles")]
    public sealed class ArticlesController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(
            [FromBody] ArticlePostBody body,
            CancellationToken ct = default)
        {
            var command = new CreateArticleCommand(body.Title, body.Content);
            var article = await Mediator.Send(command, ct);

            return Created($"api/articles/{article.Id}", article);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(
            string id,
            [FromBody] ArticlePutBody body,
            CancellationToken ct = default)
        {
            var command = new UpdateArticleCommand(id, body.Title, body.Content);
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(
            string id,
            CancellationToken ct = default)
        {
            var command = new DeleteArticleCommand(id);
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            string id,
            CancellationToken ct = default)
        {
            var query = new GetArticleByIdQuery(id);
            var article = await Mediator.Send(query, ct);

            return Ok(article);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken ct = default)
        {
            var query = new GetArticlesQuery();
            var articles = await Mediator.Send(query, ct);

            return Ok(articles);
        }

        public sealed record ArticlePostBody(string Title, string Content);

        public sealed record ArticlePutBody(string Title, string Content);
    }
}