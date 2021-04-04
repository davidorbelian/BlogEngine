using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.Application.Articles;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [Route("api/hashtags")]
    public sealed class HashTagsController : ApiController
    {
        [HttpGet("{hashTag}/articles")]
        public async Task<IActionResult> Get(
            string hashTag,
            CancellationToken ct = default)
        {
            var query = new GetArticlesByHashTagQuery(hashTag);
            var articles = await Mediator.Send(query, ct);

            return Ok(articles);
        }
    }
}