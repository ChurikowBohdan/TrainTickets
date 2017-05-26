using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace TrainTickets.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TrainTicketsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}