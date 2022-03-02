using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.Boards
{
    public class UpdateBoardCommand : CommandBase
    {
        [JsonIgnore]
        public Guid BoardId { get; set; }

        [JsonIgnore]
        public string? UserId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public override void Validate()
        {
            if (BoardId == new Guid())
                AddNotification(nameof(BoardId), "Inválido");

            new AddNotifications<UpdateBoardCommand>(this)
                .IfNullOrEmpty(x => x.UserId)
                .IfNullOrInvalidLength(x => x.Name, 1, 100);

            if (!string.IsNullOrEmpty(Description) && Description.Length > 200)
                AddNotification(nameof(Description), "Deve ter até 200 caracteres");
        }
    }
}
