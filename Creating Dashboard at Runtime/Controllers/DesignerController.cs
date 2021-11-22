using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;

namespace Creating_Dashboard_at_Runtime.Controllers
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