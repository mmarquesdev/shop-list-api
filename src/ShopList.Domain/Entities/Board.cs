using ShopList.Domain.Entities.Base;

namespace ShopList.Domain.Entities
{
    public class Board : EntityBase
    {
        public Board(string userId, string name, string? description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }

        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        
        public void Update(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
