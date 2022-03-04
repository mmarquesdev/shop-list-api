using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;
using ShopList.Infra.Context;
using ShopList.Infra.Repositories.Base;

namespace ShopList.Infra.Repositories
{
    public class BoardRepository : RepositoryBase<Board, Guid>, IBoardRepository
    {
        public BoardRepository(ShopListDbContext context) : base(context)
        {
            _context = context;
        }

        private readonly ShopListDbContext _context;
    }
}
