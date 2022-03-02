using MediatR;
using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.Boards
{
    public class UpdateBoardCommandHandler : CommandHandler, IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        public UpdateBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        private readonly IBoardRepository _boardRepository;

        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var board = _boardRepository.GetById(request.BoardId);

            if (board == null || board.UserId != request.UserId || board.DeletedAt != null)
                AddNotification(nameof(request.BoardId), "Não encontrado");
            
            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            board?.Update(request.Name, request.Description);

            _boardRepository.Update(board);
            await _boardRepository.SaveChangesAsync();

            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
