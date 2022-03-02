using MediatR;
using prmToolkit.NotificationPattern;

namespace ShopList.Domain.Commands.Base
{
    public abstract class CommandBase : Notifiable, IRequest<CommandResult>
    {
        public abstract void Validate();
    }

    public abstract class CommandHandler : Notifiable { }

    public abstract class CommandResult { }

    public class SuccessCommandResult : CommandResult { }

    public class ErrorCommandResult : CommandResult
    {
        public ErrorCommandResult(string message, IEnumerable<Notification> notifications)
        {
            Message = message;
            Notifications = notifications;
        }

        public string Message { get; private set; }
        public IEnumerable<Notification> Notifications { get; private set; }
    }
}
