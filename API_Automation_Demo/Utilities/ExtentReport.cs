using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Linq;

namespace API_Automation_Demo.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentTest scenario;
        public static ExtentTest feature;

        public static void ExtentReportInit()
        {
            string currentDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH.mm");
            string projectPath = TestHelper.GetProjectPath();
            string reportPath = Path.Combine(projectPath, "Reports", $"TestResultReport_{currentDateTime}.html");

            extent = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(sparkReporter);
            extent.AddSystemInfo("Environment", TestHelper.GetAppConfig().environment);
        }

        public static void EndReport()
        {
            extent.Flush();

            string workingDirectory = Environment.CurrentDirectory;
            System.IO.DirectoryInfo di = new DirectoryInfo(workingDirectory);

            if (di.GetFiles().Count() > Convert.ToInt32(TestHelper.GetAppConfig().maxReports))
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception)
                    {
                        //Existing log will not get deleted as its been used by other process. 
                    }
                }
            }
        }
    }
}
