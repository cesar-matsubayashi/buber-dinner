using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Commands.CreateReservation;
using BuberDinner.Application.Dinners.Commands.DeleteDinner;
using BuberDinner.Application.Dinners.Commands.UpdateDinner;
using BuberDinner.Application.Dinners.Queries.GetDinner;
using BuberDinner.Contracts.Dinners;
using BuberDinner.Contracts.Dinners.Reservations;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class DinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateDinnerRequest, CreateDinnerCommand>()
                .Map(dest => dest.HostId, src => HostId.Create(src.HostId))
                .Map(dest => dest.MenuId, src => MenuId.Create(src.MenuId));

            config.NewConfig<CreatePriceRequest, CreatePriceCommand>();

            config.NewConfig<CreateLocationRequest, CreateLocationCommand>();

            config.NewConfig<Dinner, DinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Status, src => src.Status.ToString())
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.MenuId, src => src.MenuId.Value);

            config.NewConfig<Price, PriceResponse>();

            config.NewConfig<Location, LocationResponse>();

            config.NewConfig<Reservation, DinnerReservationResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Status, src => src.Status.ToString())
                .Map(dest => dest.GuestId, src => src.GuestId.Value)
                .Map(dest => dest.BillId, src => src.BillId.Value);

            config.NewConfig<Guid, GetDinnerQuery>()
                .Map(dest => dest.Id, src => DinnerId.Create(src));

            config.NewConfig<Guid, DeleteDinnerCommand>()
                .Map(dest => dest.Id, src => DinnerId.Create(src));

            config.NewConfig<(UpdateDinnerRequest Request, Guid Id), UpdateDinnerCommand>()
                .Map(dest => dest.Id, src => DinnerId.Create(src.Id))
                .Map(dest => dest.MenuId, src => MenuId.Create(src.Request.MenuId))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<UpdatePriceRequest, UpdatePriceCommand>();

            config.NewConfig<UpdateLocationRequest, UpdateLocationCommand>();

            config.NewConfig<(CreateReservationRequest Request, Guid Id), CreateReservationCommand>()
                .Map(dest => dest.DinnerId, src => DinnerId.Create(src.Id))
                .Map(dest => dest.GuestId, src => GuestId.Create(src.Request.GuestId))
                .Map(dest => dest.BillId, src => BillId.Create(src.Request.BillId))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Reservation, ReservationResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Status, src => src.Status.ToString())
                .Map(dest => dest.GuestId, src => src.GuestId.Value)
                .Map(dest => dest.BillId, src => src.BillId.Value);

        }
    }
}
