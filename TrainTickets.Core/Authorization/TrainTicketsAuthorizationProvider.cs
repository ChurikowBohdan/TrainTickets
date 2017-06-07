using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TrainTickets.Authorization
{
    public class TrainTicketsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
			var stations = pages.CreateChildPermission(PermissionNames.Pages_Stations, L("Station"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TrainTicketsConsts.LocalizationSourceName);
        }
    }
}
