using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;

namespace Runtime_Dashboard_Creation.Controllers
{
    public class DesignerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            var report = Helpers.Dashboard.CreateTemplate();
            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}