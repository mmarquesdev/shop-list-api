using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.BoardItens
{
    public class DeleteBoardItemCommand : CommandBase
    {
        [JsonIgnore]
        public Guid BoardItemId { get; set; }

        [JsonIgnore]
        public string? UserId { get; set; }

        public override void Validate()
        {
            if (BoardItemId == new Guid())
                AddNotification(nameof(BoardItemId), "Inválido");

            new AddNotifications<DeleteBoardItemCommand>(this)
                .IfNullOrEmpty(x => x.UserId);
        }
    }
}
