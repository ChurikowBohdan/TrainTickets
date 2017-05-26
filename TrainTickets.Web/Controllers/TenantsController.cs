using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using TrainTickets.Authorization;
using TrainTickets.MultiTenancy;

namespace TrainTickets.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : TrainTicketsControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}