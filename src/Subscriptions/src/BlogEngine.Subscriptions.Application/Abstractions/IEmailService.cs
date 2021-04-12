using System.Threading.Tasks;

namespace BlogEngine.Subscriptions.Application.Abstractions
{
    public interface IEmailService
    {
        Task Send(string to, string from, string title, string message);
    }
}