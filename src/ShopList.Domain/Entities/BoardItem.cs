using ShopList.Domain.Entities.Base;

namespace ShopList.Domain.Entities
{
    public class BoardItem : EntityBase
    {
        public BoardItem(Guid boardId, bool finished, string name, int amount, decimal? unitPrice)
        {
            BoardId = boardId;
            Finished = finished;
            Name = name;
            Amount = amount;
            UnitPrice = unitPrice;
        }

        public Guid BoardId { get; private set; }
        public bool Finished { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public decimal? UnitPrice { get; private set; }

        public virtual Board? Board { get; private set; }

        public void Update(bool finished, string name, int amount, decimal? unitPrice)
        {
            Finished = finished;
            Name = name;
            Amount = amount;
            UnitPrice = unitPrice;
        }
    }
}
