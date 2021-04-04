using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.Application.Requests.Articles;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [Route("api/hashtags")]
    public sealed class HashTagsController : ApiController
    {
        [HttpGet("{id}/articles")]
        public async Task<IActionResult> Get(
            string id,
            CancellationToken ct = default)
        {
            var query = new GetArticlesByHashTagIdQuery(id);
            var articles = await Mediator.Send(query, ct);

            return Ok(articles);
        }
    }
}