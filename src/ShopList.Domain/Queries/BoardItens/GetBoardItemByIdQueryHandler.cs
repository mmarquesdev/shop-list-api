using MediatR;
using ShopList.Domain.Queries.Base;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Queries.BoardItens
{
    public class GetBoardItemByIdQueryHandler : QueryHandler, IRequestHandler<GetBoardItemByIdQuery, QueryBaseResult>
    {
        public GetBoardItemByIdQueryHandler(IBoardItemRepository boardItemRepository)
        {
            _boardItemRepository = boardItemRepository;
        }

        private readonly IBoardItemRepository _boardItemRepository;

        public async Task<QueryBaseResult> Handle(GetBoardItemByIdQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new QueryBaseErrorResult(
                    "Invalid fields", request.Notifications));

            var boardItem = _boardItemRepository.GetById(request.BoardItemId);
            var result = (GetBoardItemByIdQueryResult)boardItem;

            return await Task.FromResult(new QueryBaseSingleResult<GetBoardItemByIdQueryResult>(result));
        }
    }
}
