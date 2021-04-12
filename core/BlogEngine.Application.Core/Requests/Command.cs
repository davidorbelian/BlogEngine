using MediatR;

namespace BlogEngine.Application.Core.Requests
{
    public abstract record Command : Command<Unit>;

    public abstract record Command<T> : IRequest<T>;
}