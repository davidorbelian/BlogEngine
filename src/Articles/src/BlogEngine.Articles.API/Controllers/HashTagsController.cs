using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.API.Core.Attributes;
using BlogEngine.Articles.Application.Requests.Articles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Articles.API.Controllers
{
    [ApiRoute("hashtags")]
    public sealed class HashTagsController : ApiController
    {
        [HttpGet("{id}/articles")]
        public async Task<IActionResult> Get(
            [FromRoute] string id,
            CancellationToken ct = default)
        {
            var query = new GetArticlesByHashTagIdQuery(id);
            var articles = await Mediator.Send(query, ct);

            return Ok(articles);
        }
    }
}