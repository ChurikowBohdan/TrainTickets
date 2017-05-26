using System.Web.Mvc;

namespace TrainTickets.Web.Controllers
{
    public class AboutController : TrainTicketsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}