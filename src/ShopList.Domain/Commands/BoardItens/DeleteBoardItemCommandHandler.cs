using MediatR;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Commands.BoardItens
{
    public class DeleteBoardItemCommandHandler : CommandHandler, IRequestHandler<DeleteBoardItemCommand, CommandResult>
    {
        public DeleteBoardItemCommandHandler(
            IBoardRepository boardRepository,
            IBoardItemRepository boardItemRepository)
        {
            _boardRepository = boardRepository;
            _boardItemRepository = boardItemRepository;
        }

        private readonly IBoardRepository _boardRepository;
        private readonly IBoardItemRepository _boardItemRepository;

        public async Task<CommandResult> Handle(DeleteBoardItemCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var boardItem = _boardItemRepository.GetById(request.BoardItemId, x => x.Board);

            if (boardItem == null || boardItem.Board == null || boardItem.Board.UserId != request.UserId || boardItem.Board.DeletedAt != null)
                AddNotification(nameof(request.BoardItemId), "Não encontrado");

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            boardItem?.Delete();

            _boardItemRepository.Update(boardItem);
            await _boardItemRepository.SaveChangesAsync();

            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
