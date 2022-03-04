using MediatR;
using ShopList.Domain.Queries.Base;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Queries.Boards
{
    public class GetBoardsQueryHandler : QueryHandler, IRequestHandler<GetBoardsQuery, QueryBaseResult>
    {
        public GetBoardsQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        private readonly IBoardRepository _boardRepository;

        public async Task<QueryBaseResult> Handle(GetBoardsQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new QueryBaseErrorResult(
                    "Invalid fields", request.Notifications));

            var boards = _boardRepository.ListBy(x => x.UserId == request.UserId && x.DeletedAt == null).ToList();
            var result = boards?.Select(x => (GetBoardsQueryResult)x)?.ToList();

            return await Task.FromResult(new QueryBaseManyResult<GetBoardsQueryResult>(result));
        }
    }
}
