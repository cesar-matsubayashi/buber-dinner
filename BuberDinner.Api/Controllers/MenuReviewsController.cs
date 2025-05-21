using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.MenuReviews.Queries.GetMenuReview;
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
    }
}
