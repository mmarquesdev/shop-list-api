using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.Boards
{
    public class DeleteBoardCommand : CommandBase
    {
        [JsonIgnore]
        public Guid BoardId { get; set; }

        [JsonIgnore]
        public string? UserId { get; set; }

        public override void Validate()
        {
            if (BoardId == new Guid())
                AddNotification(nameof(BoardId), "Inválido");

            new AddNotifications<DeleteBoardCommand>(this)
                .IfNullOrEmpty(x => x.UserId);
        }
    }
}
