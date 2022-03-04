using ShopList.Domain.Entities;
using ShopList.Domain.Queries.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Queries.Boards
{
    public class GetBoardByIdQuery : QueryBase
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public Guid BoardId { get; set; }

        public override void Validate()
        {
        }
    }

    public class GetBoardByIdQueryResult
    {
        public Guid BoardId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<GetBoardByIdBoardItemQueryResult>? Items { get; set; }

        public static explicit operator GetBoardByIdQueryResult(Board v)
        {
            return new GetBoardByIdQueryResult
            {
                BoardId = v.Id,
                Name = v.Name,
                Description = v.Description,
                Items = v.BoardItems?.Select(x => (GetBoardByIdBoardItemQueryResult)x)?.ToList(),
            };
        }
    }

    public class GetBoardByIdBoardItemQueryResult
    {
        public Guid BoardItemId { get; set; }
        public bool Finished { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal? UnitPrice { get; set; }

        public static explicit operator GetBoardByIdBoardItemQueryResult(BoardItem v)
        {
            return new GetBoardByIdBoardItemQueryResult
            {
                BoardItemId = v.Id,
                Finished = v.Finished,
                Name = v.Name,
                Amount = v.Amount,
                UnitPrice = v.UnitPrice,
            };
        }
    }
}
