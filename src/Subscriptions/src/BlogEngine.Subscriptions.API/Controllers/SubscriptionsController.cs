using System.Threading;
using System.Threading.Tasks;
using BlogEngine.API.Core;
using BlogEngine.API.Core.Attributes;
using BlogEngine.Subscriptions.Application.Requests.Subscriptions.Commands;
using BlogEngine.Subscriptions.Application.Requests.Subscriptions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Subscriptions.API.Controllers
{
    [ApiRoute("subscriptions/{email}")]
    public sealed class SubscriptionsController : ApiController
    {
        [HttpPut]
        public async Task<IActionResult> Put(
            [FromRoute] string email,
            [FromBody] SubscriptionPutBody body,
            CancellationToken ct = default)
        {
            var command = new CreateOrUpdateSubscriptionCommand(email, body.HashTags);
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromRoute] string email,
            CancellationToken ct = default)
        {
            var command = new DeleteSubscriptionCommand(email);
            await Mediator.Send(command, ct);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute] string email,
            CancellationToken ct = default)
        {
            var query = new GetSubscriptionByEmailQuery(email);
            var subscription = await Mediator.Send(query, ct);

            return Ok(subscription);
        }

        public sealed record SubscriptionPutBody(string[] HashTags);
    }
}