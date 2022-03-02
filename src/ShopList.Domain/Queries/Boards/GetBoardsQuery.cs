using prmToolkit.NotificationPattern;
using ShopList.Domain.Entities;
using ShopList.Domain.Queries.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Queries.Boards
{
    public class GetBoardsQuery : QueryBase
    {
        [JsonIgnore]
        public string? UserId { get; set; }

        public override void Validate()
        {
            new AddNotifications<GetBoardsQuery>(this)
                .IfNullOrEmpty(x => x.UserId);
        }
    }

    public class GetBoardsQueryResult
    {
        public Guid BoardId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static explicit operator GetBoardsQueryResult(Board v)
        {
            return new GetBoardsQueryResult
            {
                BoardId = v.Id,
                Name = v.Name,
                Description = v.Description,
            };
        }
    }
}
