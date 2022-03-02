using System.Text.Json.Serialization;

namespace ShopList.Domain.Queries.Boards
{
    public class GetBoardByIdQuery
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public Guid BoardId { get; private set; }
    }
}
