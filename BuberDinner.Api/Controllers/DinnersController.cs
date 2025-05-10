using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Commands.DeleteDinner;
using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using BuberDinner.Application.Dinners.Queries.GetDinner;
using BuberDinner.Application.Dinners.Queries.ListDinner;
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
        public async Task<IActionResult> ListDinners() 
        {
            var query = new ListDinnersQuery();
            var listDinnersResult = await _mediator.Send(query);

            return listDinnersResult.Match(
                dinners => Ok(_mapper.Map<List<DinnerResponse>>(dinners)),
                errors => Problem(errors));
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDinner(
            Guid id)
        {
            var command = _mapper.Map<DeleteDinnerCommand>(id);
            var deleteDinnerCommand = await _mediator.Send(command);

            return deleteDinnerCommand.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDinner(
            UpdateDinnerRequest request,
            Guid id)
        {
            var command = _mapper.Map<UpdateDinnerCommand>((request, id));
            var updateDinnerResult = await _mediator.Send(command);

            return updateDinnerResult.Match(
                dinner => Ok(_mapper.Map<DinnerResponse>(dinner)),
                errors => Problem(errors));
        }
    }
}
