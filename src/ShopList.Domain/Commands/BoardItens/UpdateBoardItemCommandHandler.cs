using MediatR;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Repositories;

namespace ShopList.Domain.Commands.BoardItens
{
    public class UpdateBoardItemCommandHandler : CommandHandler, IRequestHandler<UpdateBoardItemCommand, CommandResult>
    {
        public UpdateBoardItemCommandHandler(
            IBoardRepository boardRepository,
            IBoardItemRepository boardItemRepository)
        {
            _boardRepository = boardRepository;
            _boardItemRepository = boardItemRepository;
        }

        private readonly IBoardRepository _boardRepository;
        private readonly IBoardItemRepository _boardItemRepository;

        public async Task<CommandResult> Handle(UpdateBoardItemCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var boardItem = _boardItemRepository.GetById(request.BoardItemId, x => x.Board);

            if (boardItem == null || boardItem.Board == null || boardItem.Board.UserId != request.UserId || boardItem.Board.DeletedAt != null)
                AddNotification(nameof(request.BoardItemId), "Não encontrado");

            if (this.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", this.Notifications));

            boardItem?.Update(request.Finished, request.Name, request.Amount, request.UnitPrice);
            _boardItemRepository.Update(boardItem);
            await _boardItemRepository.SaveChangesAsync();

            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
