using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace _2demo.Hooks
{
    [Binding]
    public class DemoHooks
    {
        public static ExtentReports extents;
        public static ExtentTest feature;
        public static ExtentTest scenario;
        public static LoggingLevelSwitch loggingLevel;

        [BeforeScenario]
        public void ScenarioBefore(ScenarioContext scenariocontext)
        {
            scenario = feature.CreateNode<Scenario>(scenariocontext.ScenarioInfo.Title);
            Serilog.Log.Information("selecting scenario {0} to run", scenariocontext.ScenarioInfo.Title);

        }
        [BeforeFeature]
        public static void FeatureBefore(FeatureContext featurecontext)
        {
            feature = extents.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
            Serilog.Log.Information("selecting Feature file {0} to run", featurecontext.FeatureInfo.Title);

        }
        [BeforeTestRun]
        public static void generateReport()
        {
            var htmlreport = new ExtentHtmlReporter(@"C:\Users\mindtree2090\source\repos\2demo\Utilities\report.html");
            htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extents = new ExtentReports();
            extents.AttachReporter(htmlreport);
            LoggingLevelSwitch loggingLevel = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.ControlledBy(levelSwitch: loggingLevel)
                                .WriteTo.File(@"C:\Users\mindtree2090\source\repos\2demo\Utilities\logger.Log",
                                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} |{Level:u3}|] | {Message:lj} |{NewLine}{Exception}",
                                rollingInterval: RollingInterval.Day).CreateLogger();
        }
        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenariocontext)
        {
            if (scenariocontext.TestError == null)
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (scenariocontext.TestError != null)
            {

                Log.Error("Test step failed" + scenariocontext.TestError.Message);

                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenariocontext.TestError.Message);
            }
        }
        [AfterTestRun]
        public static void CloseExtentReport()
        {
            extents.Flush();
        }
    }
}
