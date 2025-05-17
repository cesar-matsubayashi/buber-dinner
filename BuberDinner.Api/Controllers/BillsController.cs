using BuberDinner.Application.Bills.Commands.CreateBill;
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
    }
}
