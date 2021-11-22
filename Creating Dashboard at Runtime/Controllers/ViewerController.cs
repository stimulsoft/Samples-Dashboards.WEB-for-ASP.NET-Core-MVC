using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;

namespace Creating_Dashboard_at_Runtime.Controllers
{
    public class ViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetReport()
        {
            var report = Helpers.Dashboard.CreateTemplate();
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}