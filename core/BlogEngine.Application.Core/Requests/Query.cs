using MediatR;

namespace BlogEngine.Application.Core.Requests
{
    public abstract record Query<T> : IRequest<T>;
}