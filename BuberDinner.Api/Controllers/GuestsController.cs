using BuberDinner.Application.Guests.Commands.CreateGuest;
using BuberDinner.Application.Guests.Queries.GetGuest;
using BuberDinner.Contracts.Guests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class GuestsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public GuestsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest(
            CreateGuestRequest request)
        {
            var command = _mapper.Map<CreateGuestCommand>(request);
            var createGuestResult = await _mediator.Send(command);

            return createGuestResult.Match(
                guest => Ok(_mapper.Map<GuestResponse>(guest)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetGuest(
            Guid id)
        {
            var query = _mapper.Map<GetGuestQuery>(id);
            var getGuestResult = await _mediator.Send(query);

            return getGuestResult.Match(
                guest => Ok(_mapper.Map<GuestResponse>(guest)),
                errors => Problem(errors));
        }
    }
}
