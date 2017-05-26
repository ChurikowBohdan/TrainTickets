using Abp.Authorization;
using TrainTickets.Authorization.Roles;
using TrainTickets.MultiTenancy;
using TrainTickets.Users;

namespace TrainTickets.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
