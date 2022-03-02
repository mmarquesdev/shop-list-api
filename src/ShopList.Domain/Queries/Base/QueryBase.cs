using MediatR;
using prmToolkit.NotificationPattern;

namespace ShopList.Domain.Queries.Base
{
    public abstract class QueryBase : Notifiable, IRequest<QueryBaseResult>
    {
        public abstract void Validate();
    }

    public abstract class QueryHandler : Notifiable
    {

    }

    public abstract class QueryBaseResult : Notifiable
    {
    }

    public class QueryBaseSingleResult<T> : QueryBaseResult where T : class
    {
        public QueryBaseSingleResult(T? data)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }

    public class QueryBaseManyResult<T> : QueryBaseResult where T : class
    {
        public QueryBaseManyResult(List<T>? data)
        {
            Data = data;
        }

        public List<T>? Data { get; set; }
    }

    public class ErrorQueryBaseResult : QueryBaseResult
    {
        public ErrorQueryBaseResult(string message, IEnumerable<Notification> notifications)
        {
            Message = message;
            Notifications = notifications;
        }

        public string Message { get; private set; }
        public IEnumerable<Notification>? Notifications { get; private set; }
    }
}
