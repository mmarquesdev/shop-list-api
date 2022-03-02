using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;
using ShopList.Infra.Context;
using ShopList.Infra.Repositories.Base;

namespace ShopList.Infra.Repositories
{
    public class ExampleRepository : RepositoryBase<Example, Guid>, IBoardRepository
    {
        public ExampleRepository(ExampleDbContext context) : base(context)
        {
            _context = context;
        }

        private readonly ExampleDbContext _context;
    }
}
