using ShopList.Domain.Entities;
using ShopList.Domain.Repositories.Base;

namespace ShopList.Domain.Repositories
{
    public interface IBoardItemRepository : IRepositoryBase<BoardItem, Guid>
    {
    }
}
