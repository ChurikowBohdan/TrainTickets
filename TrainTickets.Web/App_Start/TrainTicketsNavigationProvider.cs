using Abp.Application.Navigation;
using Abp.Localization;
using TrainTickets.Authorization;

namespace TrainTickets.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class TrainTicketsNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
			context.Manager.MainMenu
				.AddItem(
					new MenuItemDefinition(
						"Home",
						L("HomePage"),
						url: "",
						icon: "fa fa-home",
						requiresAuthentication: true
						)
				).AddItem(
					new MenuItemDefinition(
						"Tenants",
						L("Tenants"),
						url: "Tenants",
						icon: "fa fa-globe",
						requiredPermissionName: PermissionNames.Pages_Tenants
						)
				).AddItem(
					new MenuItemDefinition(
						"Users",
						L("Users"),
						url: "Users",
						icon: "fa fa-users",
						requiredPermissionName: PermissionNames.Pages_Users
						)
				).AddItem(
					new MenuItemDefinition(
						"About",
						L("About"),
						url: "About",
						icon: "fa fa-info"
						)
				).AddItem(
					new MenuItemDefinition(
						"Stations",
						L("Stations"),
						url: "station/list",
						icon: "fa fa-users"
					)
				).AddItem(
					new MenuItemDefinition(
						"TrainTypes",
						L("TrainTypes"),
						url: "traintype/list",
						icon: "fa fa-users"
					)
				).AddItem(
					new MenuItemDefinition(
						"Trains",
						L("Trains"),
						url: "train/list",
						icon: "fa fa-users"
					)
				);

		}

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainTicketsConsts.LocalizationSourceName);
        }
    }
}
 