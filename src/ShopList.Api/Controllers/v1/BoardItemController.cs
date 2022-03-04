using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopList.Domain.Commands.Base;
using ShopList.Domain.Commands.BoardItens;
using ShopList.Domain.Queries.Base;
using ShopList.Domain.Queries.BoardItens;

namespace ShopList.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/board-items")]
    public class BoardItemController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Post(
            [FromBody] CreateBoardItemCommand request,
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

        [HttpPut("{BoardItemId}")]
        [ProducesResponseType(200, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Put(
            [FromRoute] Guid BoardItemId,
            [FromBody] UpdateBoardItemCommand request,
            [FromServices] IMediator mediator)
        {
            try
            {
                request.UserId = "teste";
                request.BoardItemId = BoardItemId;
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

        [HttpDelete("{BoardItemId}")]
        [ProducesResponseType(200, Type = typeof(SuccessCommandResult))]
        [ProducesResponseType(400, Type = typeof(ErrorCommandResult))]
        public IActionResult Delete(
            [FromRoute] Guid BoardItemId,
            [FromBody] DeleteBoardItemCommand request,
            [FromServices] IMediator mediator)
        {
            try
            {
                request.UserId = "teste";
                request.BoardItemId = BoardItemId;
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

        [HttpGet("{BoardItemId}")]
        [ProducesResponseType(200, Type = typeof(QueryBaseSingleResult<GetBoardItemByIdQueryResult>))]
        [ProducesResponseType(400, Type = typeof(QueryBaseErrorResult))]
        public IActionResult GetById(
            [FromRoute] Guid BoardItemId,
            [FromServices] IMediator mediator)
        {
            try
            {
                GetBoardItemByIdQuery request = new GetBoardItemByIdQuery();
                request.UserId = "teste";
                request.BoardItemId = BoardItemId;
                var response = mediator.Send(request).Result;

                if (response.GetType() == typeof(QueryBaseSingleResult<GetBoardItemByIdQueryResult>))
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
