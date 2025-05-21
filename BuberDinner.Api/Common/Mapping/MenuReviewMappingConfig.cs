using BuberDinner.Application.MenuReviews.Commands.CreateMenuReview;
using BuberDinner.Application.MenuReviews.Commands.DeleteMenuReview;
using BuberDinner.Application.MenuReviews.Commands.UpdateMenuReview;
using BuberDinner.Application.MenuReviews.Queries.GetMenuReview;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByGuestId;
using BuberDinner.Application.MenuReviews.Queries.ListMenuReviewsByMenuId;
using BuberDinner.Contracts.MenuReview;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class MenuReviewMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(
                CreateMenuReviewRequest Request,
                Guid HostId,
                Guid MenuId), CreateMenuReviewCommand>()
                .Map(dest => dest.HostId, src => HostId.Create(src.HostId))
                .Map(dest => dest.MenuId, src => MenuId.Create(src.MenuId))
                .Map(dest => dest.Rating, src => Rating.CreateNew(src.Request.Rating))
                .Map(dest => dest.GuestId, src => GuestId.Create(src.Request.GuestId))
                .Map(dest => dest.DinnerId, src => DinnerId.Create(src.Request.DinnerId))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<MenuReview, MenuReviewResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Rating, src => src.Rating.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.MenuId, src => src.MenuId.Value)
                .Map(dest => dest.GuestId, src => src.GuestId.Value)
                .Map(dest => dest.DinnerId, src => src.DinnerId.Value);

            config.NewConfig<Guid, GetMenuReviewQuery>()
                .Map(dest => dest.Id, src => MenuReviewId.Create(src));

            config.NewConfig<Guid, ListMenuReviewsByGuestIdQuery>()
                .Map(dest => dest.GuestId, src => GuestId.Create(src));

            config.NewConfig<Guid, ListMenuReviewsByMenuIdQuery>()
                .Map(dest => dest.MenuId, src => MenuId.Create(src));

            config.NewConfig<Guid, DeleteMenuReviewCommand>()
                .Map(dest => dest.Id, src => MenuReviewId.Create(src));

            config.NewConfig<(UpdateMenuReviewRequest Request, Guid Id), UpdateMenuReviewCommand>()
               .Map(dest => dest.Id, src => MenuReviewId.Create(src.Id))
               .Map(dest => dest.Rating, src => Rating.CreateNew(src.Request.Rating))
               .Map(dest => dest, src => src.Request);
        }
    }
}
