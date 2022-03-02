using ShopList.Domain.Entities;
using ShopList.Domain.Repositories.Base;

namespace ShopList.Domain.Repositories
{
    public interface IBoardRepository : IRepositoryBase<Board, Guid>
    {
    }
}
