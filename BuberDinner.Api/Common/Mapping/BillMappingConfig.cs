using BuberDinner.Application.Bills.Commands.CreateBill;
using BuberDinner.Contracts.Bills;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class BillMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateBillRequest, CreateBillCommand>()
                .Map(dest => dest.DinnerId, src => DinnerId.Create(src.DinnerId))
                .Map(dest => dest.GuestId, src => GuestId.Create(src.GuestId))
                .Map(dest => dest.HostId, src => HostId.Create(src.HostId));

            config.NewConfig<CreatePriceRequest, CreatePriceCommand>();

            config.NewConfig<Bill, BillsResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.DinnerId, src => src.DinnerId.Value)
                .Map(dest => dest.GuestId, src => src.GuestId.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value);

            config.NewConfig<Price, PriceResponse>();
        }
    }
}
