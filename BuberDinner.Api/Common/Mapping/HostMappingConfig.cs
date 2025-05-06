using BuberDinner.Application.Hosts.Commands.CreateHost;
using BuberDinner.Contracts.Hosts;
using BuberDinner.Domain.User.ValueObjects;
using Mapster;

using Host = BuberDinner.Domain.Host.Host;

namespace BuberDinner.Api.Common.Mapping
{
    public class HostMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateHostRequest, CreateHostCommand>()
                .Map(dest => dest.UserId, src => UserId.Create(src.UserId));

            config.NewConfig<Host, HostResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.AverageRating,
                    src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (double?)null)
                .Map(dest => dest.MenuIds,
                    src => src.MenuIds.Select(menuId => menuId.Value))
                .Map(dest => dest.DinnerIds,
                    src => src.DinnerIds.Select(dinnerId => dinnerId.Value));

        } 
    }
}
