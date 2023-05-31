using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Dashboard.Components;
using Stimulsoft.Report;
using Stimulsoft.Report.Dashboard.Styles;
using Stimulsoft.Report.Mvc;
using System.Drawing;

namespace Using_the_Dashboard_Theme_on_the_Website.Controllers
{
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index(string id = "DashboardChristmas")
        {
            var report = StiReport.CreateNewDashboard();
            report.Load(StiNetCoreHelper.MapPath(this, $"Dashboards/{id}.mrt"));

            // Get theme colors from the dashboard page
            var dashboard = report.Pages[0] as StiDashboard;
            ViewBag.DashboardBackHtmlColor = ColorTranslator.ToHtml(dashboard != null ? StiDashboardStyleHelper.GetDashboardBackColor(dashboard, true) : Color.White);
            ViewBag.BackHtmlColor = ColorTranslator.ToHtml(dashboard != null ? StiDashboardStyleHelper.GetBackColor(dashboard) : Color.White);
            ViewBag.ForeHtmlColor = ColorTranslator.ToHtml(dashboard != null ? StiDashboardStyleHelper.GetForeColor(dashboard) : Color.Black);
            // Then use it on the _Layout.cshtml

            return View();
        }
        
        public IActionResult GetReport(string id = "DashboardChristmas")
        {
            // Create the dashboard object
            var report = StiReport.CreateNewDashboard();

            // Load dashboard template
            report.Load(StiNetCoreHelper.MapPath(this, $"Dashboards/{id}.mrt"));

            // Return template to the Viewer
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}