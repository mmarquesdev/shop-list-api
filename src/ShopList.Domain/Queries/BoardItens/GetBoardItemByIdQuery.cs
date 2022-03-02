
using System.Text.Json.Serialization;

namespace ShopList.Domain.Queries.BoardItens
{
    public class GetBoardItemByIdQuery
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public Guid BoardItemId { get; private set; }
    }
}
