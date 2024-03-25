using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Contracts.Responses;
using Transactions.Application.Handlers.Cards;

namespace Transactions.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpGet("cards-list/{userId}")]
        public async Task<IActionResult> GetCardList(GetUserCardsQueryHandler handler, [FromQuery]Guid userId)
        {
            var repsonse = await handler.HandleAsync(userId);

            return Ok(repsonse);
        }

        [HttpGet("card/{id}")]
        public async Task<IActionResult> GetCard(GetDetailCardQueryHandler handler, [FromQuery] Guid id)
        {
            var result = await handler.HandleAsync(id);

            return Ok(result);
        }

        [HttpPost("create-card")]
        public async Task<IActionResult> CreateCard([FromServices] CreateCardCommandHandler handler, [FromBody] CreateCardRequest request)
        {
            var response = await handler.HandleAsync(request);

            return response.IsValid ? Ok() : BadRequest(response.Errors);
        }

        [HttpDelete("delete-card/{id}")]
        public async Task<IActionResult> DeleteCard(DeleteCardCommandHandler handler, [FromQuery]Guid id)
        {
            var response = await handler.HandleAsync(id);

            return Ok(response);
        }
    }
}