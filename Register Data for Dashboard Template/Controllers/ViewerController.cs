using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace Show_Dashboard_in_the_Viewer.Controllers
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

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetReport()
        {
            // Create new dashboard
            var report = StiReport.CreateNewDashboard();

            // Load dashboard template
            report.Load(StiNetCoreHelper.MapPath(this, "Dashboards/Dashboard.mrt"));

            // Load a JSON file
            var jsonBytes = System.IO.File.ReadAllBytes(StiNetCoreHelper.MapPath(this, "Dashboards/Demo.json"));

            // Get DataSet from JSON file
            var json = StiJsonConnector.Get();
            var dataSet = json.GetDataSet(new StiJsonOptions(jsonBytes));

            // Remove all connections from the dashboard template
            report.Dictionary.Databases.Clear();

            // Register DataSet object
            report.RegData("Demo", "Demo", dataSet);

            // Return template to the Viewer
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}