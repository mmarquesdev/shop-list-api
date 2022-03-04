using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.BoardItens
{
    public class CreateBoardItemCommand : CommandBase
    {
        [JsonIgnore]
        public string? UserId { get; set; }

        public Guid BoardId { get; set; }
        public bool Finished { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal? UnitPrice { get; set; }

        public override void Validate()
        {
            new AddNotifications<CreateBoardItemCommand>(this)
                .IfNullOrEmpty(x => x.UserId)
                .IfNullOrInvalidLength(x => x.Name, 1, 100);

            if (UnitPrice.HasValue && UnitPrice.Value < 0)
                AddNotification(nameof(UnitPrice), "Deve ser maior ou igual a zero");

            if (Amount <= 0)
                AddNotification(nameof(Amount), "Deve ser maior ou igual a zero");
        }
    }
}
