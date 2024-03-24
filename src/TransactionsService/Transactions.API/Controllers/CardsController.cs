using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Contracts.Requests;
using Transactions.Application.Contracts.Responses;

namespace Transactions.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpGet("cards-list/{userId}")]
        public IActionResult GetCardList(Guid userId)
        {
            return Ok(new List<CardItemResponse>());
        }

        [HttpGet("card/{userId}")]
        public IActionResult GetCard(Guid userId, Guid id)
        {
            return Ok(new FullCardResponse());
        }

        [HttpPost("create-card")]
        public IActionResult CreateCard(CreateCardRequest request)
        {
            return Ok(Guid.Empty);
        }

        [HttpDelete("delete-card")]
        public IActionResult DeleteCard(Guid id)
        {
            return Ok(Guid.Empty);
        }
    }
}