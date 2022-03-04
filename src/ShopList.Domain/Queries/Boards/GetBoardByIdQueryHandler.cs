using MediatR;
using ShopList.Domain.Queries.Base;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Queries.Boards
{
    public class GetBoardByIdQueryHandler : QueryHandler, IRequestHandler<GetBoardByIdQuery, QueryBaseResult>
    {
        public GetBoardByIdQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        private readonly IBoardRepository _boardRepository;

        public async Task<QueryBaseResult> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new QueryBaseErrorResult(
                    "Invalid fields", request.Notifications));

            var board = _boardRepository.GetById(request.BoardId, x => x.BoardItems.Where(x => x.DeletedAt == null));

            if (board == null || board.UserId != request.UserId || board.DeletedAt != null)
                AddNotification(nameof(request.BoardId), "Não encontrado");

            if (this.IsInvalid())
                return await Task.FromResult(new QueryBaseErrorResult("Invalid fields", this.Notifications));

            var result = (GetBoardByIdQueryResult)board;

            return await Task.FromResult(new QueryBaseSingleResult<GetBoardByIdQueryResult>(result));
        }
    }
}
