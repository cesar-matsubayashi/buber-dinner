using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview;
using BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview;
using BuberDinner.Application.MenuReviews.Queries.GetMenuReview;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId;
using BuberDinner.Contracts.MenuReview;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus/{menuId}/menureviews")]
    public class MenuReviewsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenuReviewsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuReview(
            CreateMenuReviewRequest request,
            Guid hostId,
            Guid menuId)
        {
            var command = _mapper.Map<CreateMenuReviewCommand>((request, hostId, menuId));
            var createMenuReviewCommand = await _mediator.Send(command);

            return createMenuReviewCommand.Match(
                menuReview => Ok(_mapper.Map<MenuReviewResponse>(menuReview)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMenuReview(
            Guid Id)
        {
            var query = _mapper.Map<GetMenuReviewQuery>(Id);
            var getMenuReviewQuery = await _mediator.Send(query);

            return getMenuReviewQuery.Match(
                menuReview => Ok(_mapper.Map<MenuReviewResponse>(menuReview)),
                errors => Problem(errors));
        }

        [HttpGet("guests/{guestId:guid}")]
        public async Task<IActionResult> ListMenuReviewsByGuestId(
            Guid guestId)
        {
            var query = _mapper.Map<ListMenuReviewsByGuestIdQuery>(guestId);
            var listMenuReviewsByGuestIdQuery = await _mediator.Send(query);

            return listMenuReviewsByGuestIdQuery.Match(
                menuReviews => Ok(_mapper.Map<List<MenuReviewResponse>>(menuReviews)),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> ListMenuReviewsByMenuId(
            Guid menuId)
        {
            var query = _mapper.Map<ListMenuReviewsByMenuIdQuery>(menuId);
            var listMenuReviewsByMenuIdQuery = await _mediator.Send(query);

            return listMenuReviewsByMenuIdQuery.Match(
                menuReviews => Ok(_mapper.Map<List<MenuReviewResponse>>(menuReviews)),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMenuReview(
            Guid id)
        {
            var command = _mapper.Map<DeleteMenuReviewCommand>(id);
            var deleteMenuReviewCommand = await _mediator.Send(command);

            return deleteMenuReviewCommand.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMenuReview(
            UpdateMenuReviewRequest request,
            Guid id)
        {
            var command = _mapper.Map<UpdateMenuReviewCommand>((request, id));
            var updateMenuReviewCommand = await _mediator.Send(command);

            return updateMenuReviewCommand.Match(
                menuReview => Ok(_mapper.Map<MenuReviewResponse>(menuReview)),
                errors => Problem(errors));
        }
    }
}
