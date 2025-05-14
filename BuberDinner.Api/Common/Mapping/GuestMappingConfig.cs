using BuberDinner.Application.Guests.Commands.CreateGuest;
using BuberDinner.Application.Guests.Commands.DeleteGuest;
using BuberDinner.Application.Guests.Commands.UpdateGuest;
using BuberDinner.Application.Guests.Queries.GetGuest;
using BuberDinner.Contracts.Guests;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class GuestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateGuestRequest, CreateGuestCommand>()
                .Map(dest => dest.UserId, src => UserId.Create(src.UserId));

            config.NewConfig<Guest, GuestResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.AverageRating,
                    src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (double?)null)
                .Map(dest => dest.UpcomingDinnerIds,
                    src => src.UpcomingDinnerIds.Select(menuId => menuId.Value))
                .Map(dest => dest.PastDinnerIds,
                    src => src.PastDinnerIds.Select(menuId => menuId.Value))
                .Map(dest => dest.PendingDinnerIds,
                    src => src.PendingDinnerIds.Select(menuId => menuId.Value))
                .Map(dest => dest.BillIds,
                    src => src.BillIds.Select(menuId => menuId.Value))
                .Map(dest => dest.MenuReviewIds,
                    src => src.MenuReviewIds.Select(dinnerId => dinnerId.Value));

            config.NewConfig<GuestRating, GuestRatingResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerId, src => src.DinnerId.Value)
                .Map(dest => dest.Rating, src => src.Rating.Value);

            config.NewConfig<Guid, GetGuestQuery>()
                .Map(dest => dest.Id, src => GuestId.Create(src));

            config.NewConfig<(UpdateGuestRequest Request, Guid Id), UpdateGuestCommand>()
                .Map(dest => dest.Id, src => GuestId.Create(src.Id))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Guid, DeleteGuestCommand>()
                .Map(dest => dest.Id, src => GuestId.Create(src));
        }
    }
}
