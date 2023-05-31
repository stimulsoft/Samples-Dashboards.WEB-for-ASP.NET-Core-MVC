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
            var appPath = StiNetCoreHelper.MapPath(this, string.Empty);
            var dashboard = Helpers.Dashboard.CreateTemplate(appPath);
            return StiNetCoreViewer.GetReportResult(this, dashboard);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}