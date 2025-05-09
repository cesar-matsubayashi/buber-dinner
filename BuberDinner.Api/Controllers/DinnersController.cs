using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Queries.GetDinner;
using BuberDinner.Contracts.Dinners;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public DinnersController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ListDinners() 
        {
            return Ok(Array.Empty<string>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDinner(
            CreateDinnerRequest request)
        {
            var command = _mapper.Map<CreateDinnerCommand>(request);
            var createDinnerResult = await _mediator.Send(command);

            return createDinnerResult.Match(
                dinner => Ok(_mapper.Map<DinnerResponse>(dinner)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDinner(
            Guid id)
        {
            var query = _mapper.Map<GetDinnerQuery>(id);
            var getDinnerQuery = await _mediator.Send(query);

            return getDinnerQuery.Match(
                dinner => Ok(_mapper.Map<DinnerResponse>(dinner)),
                errors => Problem(errors));
        }
    }
}
