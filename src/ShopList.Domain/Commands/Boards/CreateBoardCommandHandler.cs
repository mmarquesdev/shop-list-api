using MediatR;
using prmToolkit.NotificationPattern;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Entities;
using ShopList.Domain.Repositories;
using System.Text.Json.Serialization;

namespace ShopList.Domain.Commands.Boards
{
    public class CreateBoardCommandHandler : CommandHandler, IRequestHandler<CreateBoardCommand, CommandResult>
    {
        public CreateBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        private readonly IBoardRepository _boardRepository;

        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));

            var board = new Board(request.UserId, request.Name, request.Description);
            await _boardRepository.AddAsync(board);
            await _boardRepository.SaveChangesAsync();

            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
