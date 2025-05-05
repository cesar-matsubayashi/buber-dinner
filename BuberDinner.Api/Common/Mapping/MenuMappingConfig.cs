using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Commands.DeleteMenu;
using BuberDinner.Application.Menus.Commands.UpdateMenu;
using BuberDinner.Application.Menus.Queries.GetMenuById;
using BuberDinner.Application.Menus.Queries.List;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.AverageRating,
                    src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (double?)null)
                .Map(dest => dest.HostId, src => src.HostId.Value.ToString())
                .Map(dest => dest.DinnerIds,
                    src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds,
                    src => src.MenuReviewIds.Select(menuId => menuId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString());

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString());

            config.NewConfig<Guid, GetMenuQuery>()
                .MapWith(id => new GetMenuQuery(MenuId.Create(id)));

            config.NewConfig<(UpdateMenuRequest Request, Guid Id), UpdateMenuCommand>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Guid, DeleteMenuCommand>()
                .MapWith(id => new DeleteMenuCommand(MenuId.Create(id)));

            config.NewConfig<Guid, ListMenuQuery>()
                .MapWith(id => new ListMenuQuery(HostId.Create(id)));
        }
    }
}
