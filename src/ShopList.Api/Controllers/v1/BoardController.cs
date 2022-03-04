using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Commands.Boards;
using ShopList.Domain.Queries.Base;
using ShopList.Domain.Queries.Boards;

namespace ShopList.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/boards")]
    public class BoardController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Post(
            [FromBody] CreateBoardCommand request,
            [FromServices] IMediator mediator)
        {
            try
            {
                request.UserId = "teste";
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(SuccessCommandResult))
                    return StatusCode(201, response);
                else
                    return StatusCode(400, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{boardId}")]
        [ProducesResponseType(200, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Put(
            [FromRoute] Guid boardId,
            [FromBody] UpdateBoardCommand request,
            [FromServices] IMediator mediator)
        {
            try
            {
                request.UserId = "teste";
                request.BoardId = boardId;
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(SuccessCommandResult))
                    return StatusCode(200, response);
                else
                    return StatusCode(400, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{boardId}")]
        [ProducesResponseType(200, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Delete(
            [FromRoute] Guid boardId,
            [FromBody] DeleteBoardCommand request,
            [FromServices] IMediator mediator)
        {
            try
            {
                request.UserId = "teste";
                request.BoardId = boardId;
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(SuccessCommandResult))
                    return StatusCode(200, response);
                else
                    return StatusCode(400, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{boardId}")]
        [ProducesResponseType(200, Type = typeof(QueryBaseSingleResult<GetBoardByIdQueryResult>))]
        [ProducesResponseType(400, Type = typeof(QueryBaseErrorResult))]
        public IActionResult GetById(
            [FromRoute] Guid boardId,
            [FromServices] IMediator mediator)
        {
            try
            {
                GetBoardByIdQuery request = new GetBoardByIdQuery();
                request.UserId = "teste";
                request.BoardId = boardId;
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(QueryBaseSingleResult<GetBoardByIdQueryResult>))
                    return StatusCode(200, response);
                else
                    return StatusCode(400, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(QueryBaseManyResult<GetBoardsQueryResult>))]
        [ProducesResponseType(400, Type = typeof(QueryBaseErrorResult))]
        public IActionResult GetAll(
            [FromServices] IMediator mediator)
        {
            try
            {
                GetBoardsQuery request = new GetBoardsQuery();
                request.UserId = "teste";
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(QueryBaseManyResult<GetBoardsQueryResult>))
                    return StatusCode(200, response);
                else
                    return StatusCode(400, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
