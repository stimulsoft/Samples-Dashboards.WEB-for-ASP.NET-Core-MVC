using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Dashboard.Components;
using Stimulsoft.Report;
using Stimulsoft.Report.Dashboard.Styles;
using Stimulsoft.Report.Mvc;
using System.Drawing;
using System.IO;

namespace Show_Dashboard_in_the_Viewer.Controllers
{
    public class ViewController : Controller
    {
        private IWebHostEnvironment environment;

        static ViewController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }
        
        public ViewController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        
        public IActionResult Dashboards()
        {
            var dashboardFiles = Directory.GetFiles($"{environment.ContentRootPath}/Dashboards", "*.mrt");
            var fileNames = new string[dashboardFiles.Length];
            var index = 0;
            foreach (var filePath in dashboardFiles)
            {
                fileNames[index++] = Path.GetFileNameWithoutExtension(filePath);
            }

            ViewBag.FileNames = fileNames;

            var fileName = RouteData.Values["id"].ToString();
            var report = StiReport.CreateNewDashboard();
            report.Load(StiNetCoreHelper.MapPath(this, $"Dashboards/{fileName}.mrt"));

            var dashboard = report.Pages[0] as StiDashboard;
            ViewBag.ForeHtmlColor = ColorTranslator.ToHtml(dashboard != null ? StiDashboardStyleHelper.GetForeColor(dashboard) : Color.Black);
            ViewBag.BackHtmlColor = ColorTranslator.ToHtml(dashboard != null ? StiDashboardStyleHelper.GetDashboardBackColor(dashboard, true) : Color.White);
            ViewBag.BackColor = dashboard != null ? StiDashboardStyleHelper.GetDashboardBackColor(dashboard, true) : Color.White;

            return View();
        }

        public IActionResult GetReport(string id)
        {
            var report = StiReport.CreateNewDashboard();
            report.Load(StiNetCoreHelper.MapPath(this, "/Dashboards/" + id + ".mrt"));

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult Design(string id)
        {
            return RedirectToAction("Dashboards", "Design", new { id });
        }
    }
}