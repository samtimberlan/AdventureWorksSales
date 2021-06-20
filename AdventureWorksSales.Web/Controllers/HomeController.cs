using AdventureWorksSales.Services;
using AdventureWorksSales.Web.ViewModels;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReportService _reportService;
        public HomeController()
        {
            _reportService = new ReportService();
        }
        public ActionResult Index()
        {
            return View(new ReportViewModel 
            { 
                TotalOrders = _reportService.GetTotalOrders(),
                HighestLineTotal = _reportService.GetHighestLineTotal(),
                FrontBrakesSalesTotal = _reportService.GetFrontBrakesTotal()
            });
        }

    }
}