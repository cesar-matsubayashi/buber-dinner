using BuberDinner.Application.Hosts.Commands.CreateHost;
using BuberDinner.Application.Hosts.Queries.GetHost;
using BuberDinner.Contracts.Hosts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class HostsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public HostsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHost(
            CreateHostRequest request)
        {
            var command = _mapper.Map<CreateHostCommand>(request);
            var createHostResult = await _mediator.Send(command);

            return createHostResult.Match(
                host => Ok(_mapper.Map<HostResponse>(host)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetHostById(Guid id)
        {
            var query = _mapper.Map<GetHostQuery>(id);
            var getHostResult = await _mediator.Send(query);

            return getHostResult.Match(
                host => Ok(_mapper.Map<HostResponse>(host)),
                errors => Problem(errors));
        }
    }
}
