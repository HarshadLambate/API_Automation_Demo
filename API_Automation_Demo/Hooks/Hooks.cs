using API_Automation_Demo.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using TechTalk.SpecFlow;

namespace API_Automation_Demo.Hooks
{
    [Binding]
    public sealed class Hooks: ExtentReport
    {
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ExtentReportInit();
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
            var stepName = scenarioContext.StepContext.StepInfo.Text;
            var stepStatus = scenarioContext.TestError;

            if (scenarioContext.TestError == null)
            {
                switch (stepType.ToString())
                {
                    case "Given":
                        scenario.CreateNode<Given>(stepName).Pass("Pass");
                        break;
                    case "When":
                        scenario.CreateNode<When>(stepName).Pass("Pass");
                        break;
                    case "And":
                        scenario.CreateNode<And>(stepName).Pass("Pass");
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(stepName).Pass("Pass");
                        break;
                }
            }
            else
            {
                switch (stepType.ToString())
                {
                    case "Given":
                        scenario.CreateNode<Given>(stepName).Fail(stepStatus.Message);
                        break;
                    case "When":
                        scenario.CreateNode<When>(stepName).Fail(stepStatus.Message);
                        break;
                    case "And":
                        scenario.CreateNode<And>(stepName).Fail(stepStatus.Message);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(stepName).Fail(stepStatus.Message);
                        break;
                }
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            EndReport();
        }
    }
}
