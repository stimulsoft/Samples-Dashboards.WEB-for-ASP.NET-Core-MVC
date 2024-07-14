using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exporting_and_Printing_a_Dashboard_from_Code.Models;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace Exporting_and_Printing_a_Dashboard_from_Code.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HomeController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private StiReport GetDashboard()
        {
            var reportPath = StiNetCoreHelper.MapPath(this, "Dashboards/DashboardChristmas.mrt");
            var report = StiReport.CreateNewDashboard();
            report.Load(reportPath);

            return report;
        }

        public IActionResult PrintPdf()
        {
            var report = this.GetDashboard();
            return StiNetCoreReportResponse.PrintAsPdf(report);
        }

        public IActionResult PrintHtml()
        {
            var report = this.GetDashboard();
            return StiNetCoreReportResponse.PrintAsHtml(report);
        }

        public IActionResult ExportPdf()
        {
            var report = this.GetDashboard();
            return StiNetCoreReportResponse.ResponseAsPdf(report);
        }

        public IActionResult ExportExcel()
        {
            var report = this.GetDashboard();
            return StiNetCoreReportResponse.ResponseAsExcel2007(report);
        }

        public IActionResult ExportImage()
        {
            var report = this.GetDashboard();
            return StiNetCoreReportResponse.ResponseAsPng(report);
        }
    }
}
