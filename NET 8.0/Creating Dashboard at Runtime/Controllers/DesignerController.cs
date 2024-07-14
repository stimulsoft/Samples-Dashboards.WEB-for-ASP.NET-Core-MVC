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
            var appPath = StiNetCoreHelper.MapPath(this, string.Empty);
            var dashboard = Helpers.Dashboard.CreateTemplate(appPath);
            return StiNetCoreDesigner.GetReportResult(this, dashboard);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}