using BuberDinner.Application.Guests.Commands.CreateGuest;
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
    }
}
