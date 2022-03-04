using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;
using ShopList.Infra.Context;
using ShopList.Infra.Repositories.Base;

namespace ShopList.Infra.Repositories
{
    public class BoardItemRepository : RepositoryBase<BoardItem, Guid>, IBoardItemRepository
    {
        public BoardItemRepository(ShopListDbContext context) : base(context)
        {
            _context = context;
        }

        private readonly ShopListDbContext _context;
    }
}
