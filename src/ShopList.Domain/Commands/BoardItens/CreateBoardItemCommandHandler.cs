using MediatR;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Commands.BoardItens
{
    public class CreateBoardItemCommandHandler : CommandHandler, IRequestHandler<CreateBoardItemCommand, CommandResult>
    {
        public CreateBoardItemCommandHandler(
            IBoardRepository boardRepository,
            IBoardItemRepository boardItemRepository)
        {
            _boardRepository = boardRepository;
            _boardItemRepository = boardItemRepository;
        }

        private readonly IBoardRepository _boardRepository;
        private readonly IBoardItemRepository _boardItemRepository;

        public async Task<CommandResult> Handle(CreateBoardItemCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var board = _boardRepository.GetById(request.BoardId);
            if (board == null || board.UserId != request.UserId || board.DeletedAt != null)
                AddNotification(nameof(request.BoardId), "Não encontrado");

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var boardItem = new BoardItem(request.BoardId, request.Finished, request.Name, request.Amount, request.UnitPrice);
            await _boardItemRepository.AddAsync(boardItem);
            await _boardItemRepository.SaveChangesAsync();

            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
