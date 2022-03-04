
using ShopList.Domain.Entities;
using ShopList.Domain.Queries.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Queries.BoardItens
{
    public class GetBoardItemByIdQuery : QueryBase
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public Guid BoardItemId { get; set; }

        public override void Validate()
        {

        }
    }

    public class GetBoardItemByIdQueryResult
    {
        public Guid BoardId { get; set; }
        public Guid BoardItemId { get; set; }
        public bool Finished { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal? UnitPrice { get; set; }

        public static explicit operator GetBoardItemByIdQueryResult(BoardItem v)
        {
            return new GetBoardItemByIdQueryResult
            {
                BoardId = v.BoardId,
                BoardItemId = v.Id,
                Finished = v.Finished,
                Name = v.Name,
                Amount = v.Amount,
                UnitPrice = v.UnitPrice,
            };
        }
    }
}
