using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Commands.DeleteMenu;
using BuberDinner.Application.Menus.Commands.UpdateMenu;
using BuberDinner.Application.Menus.Queries.GetMenuById;
using BuberDinner.Application.Menus.Queries.List;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMenuById(Guid id)
        {
            var query = _mapper.Map<GetMenuQuery>(id);
            var getMenuResult = await _mediator.Send(query);

            return getMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> ListMenus(Guid hostId)
        {
            var query = _mapper.Map<ListMenuQuery>(hostId);
            var getMenuResult = await _mediator.Send(query);

            return getMenuResult.Match(
                menu => Ok(_mapper.Map<List<MenuResponse>>(menu)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMenu(
            UpdateMenuRequest request,
            Guid id)
        {
            var command = _mapper.Map<UpdateMenuCommand>((request, id));
            var updateMenuResult = await _mediator.Send(command);

            return updateMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMenu(Guid id)
        {
            var command = _mapper.Map<DeleteMenuCommand>(id);
            var deleteMenuResult = await _mediator.Send(command);

            return deleteMenuResult.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }
    }
}
