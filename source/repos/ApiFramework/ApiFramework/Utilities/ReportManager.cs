using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public class ReportManager
{
    public static ExtentReports extent=null!;
    public static ExtentTest test=null!;

    public static void Init()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;

        var reportPath = Path.Combine(basePath, "test", "Reports");

        Directory.CreateDirectory(reportPath);

        var fullPath = Path.Combine(reportPath, "report.html");

        var spark = new ExtentSparkReporter(fullPath);

        extent = new ExtentReports();
        extent.AttachReporter(spark);
    }

    public static void Flush()
    {
        extent.Flush();
    }
}