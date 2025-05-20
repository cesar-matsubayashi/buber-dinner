using BuberDinner.Application.Bills.Commands.CreateBill;
using BuberDinner.Application.Bills.Queries.GetBill;
using BuberDinner.Contracts.Bills;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class BillsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public BillsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(
            CreateBillRequest request)
        {
            var command = _mapper.Map<CreateBillCommand>(request);
            var createBillCommand = await _mediator.Send(command);

            return createBillCommand.Match(
                bill => Ok(_mapper.Map<BillsResponse>(bill)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBill(
            Guid id)
        {
            var query = _mapper.Map<GetBillQuery>(id);
            var getBillQuery = await _mediator.Send(query);

            return getBillQuery.Match(
                bill => Ok(_mapper.Map<BillsResponse>(bill)),
                errors => Problem(errors));
        }
    }
}
