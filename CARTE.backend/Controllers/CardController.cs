using AutoMapper;
using Infrastructure.Card.Commands.CreateCard;
using Infrastructure.Card.Commands.DeleteCard;
using Infrastructure.Card.Commands.UpdateCard;
using Infrastructure.Card.Queries.GetBusinessCardDetail;
using Infrastructure.Card.Queries.GetListCards;
using Microsoft.AspNetCore.Mvc;

namespace CARTE.backend.Controllers
{
    public class CardController : BaseController
    {
        private readonly IMapper _mapper;

        public CardController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet("{userId}")]
        public async Task<ActionResult<CardsListVm>> GetCardList(Guid userId)
        {
            var query = new GetListCardsQuery { Id = userId };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCardVm>> GetCard(Guid id)
        {
            var query = new GetBusinessCardQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCard([FromBody] CreateCardCommand createCard)
        {
            var command = createCard;
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCard([FromBody] UpdateCardCommand updateCard)
        {
            var command = updateCard;
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}./{userId}")]
        public async Task<ActionResult> DeleteCard(Guid id, Guid userId)
        {
            var command = new DeleteCardCommand 
            { 
                Id = id,
                UserId = userId 
            };
            await Mediator.Send(command);
            return Ok();
        }
    }
}
