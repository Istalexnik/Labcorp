using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LabcorpProject.POM;
using NUnit.Framework;

namespace LabcorpProject.StepDefinitions
{
    [Binding]
    public class JobSearchStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;
        private readonly CareersPage careersPage;
        private readonly JobsPage jobsPage;
        private readonly JobDescriptionPage jobDescriptionPage;
        private readonly LoginPage loginPage;

        public JobSearchStepDefinitions()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            careersPage = new CareersPage(driver);
            jobsPage = new JobsPage(driver);
            jobDescriptionPage = new JobDescriptionPage(driver);
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl("https://www.labcorp.com");
            homePage.CloseCookieBanner();
        }

        [When(@"I go to the Careers page")]
        public void WhenIGoToTheCareersPage()
        {
            homePage.GoToCareers();
        }

        [When(@"I search for '(.*)' on the Jobs page")]
        public void WhenISearchForOnTheJobsPage(string jobTitle)
        {
            careersPage.SearchForJob(jobTitle);
        }

        [When(@"I click on the job with title '(.*)'")]
        public void WhenIClickOnTheJobWithTitle(string jobTitle)
        {
            jobsPage.SelectJob(jobTitle);
        }

        [Then(@"the job title should be '(.*)'")]
        public void ThenTheJobTitleShouldBe(string expectedJobTitle)
        {
            string actualJobTitle = jobDescriptionPage.GetJobTitle();
            Assert.AreEqual(expectedJobTitle, actualJobTitle);
        }

        [Then(@"the job location should be '(.*)'")]
        public void ThenTheJobLocationShouldBe(string expectedJobLocation)
        {
            string actualJobLocation = jobDescriptionPage.GetJobLocation();
            Assert.AreEqual(expectedJobLocation, actualJobLocation);
        }

        [Then(@"the job ID should be '(.*)'")]
        public void ThenTheJobIDShouldBe(string expectedJobId)
        {
            string actualJobId = jobDescriptionPage.GetJobId();
            Assert.AreEqual(expectedJobId, actualJobId);
        }

        [Then(@"the job requirements should include '(.*)'")]
        public void ThenTheJobRequirementsShouldInclude(string expectedJobRequirements)
        {
            string actualJobRequirements = jobDescriptionPage.GetJobRequirements();
            Assert.IsTrue(actualJobRequirements.Contains(expectedJobRequirements));
        }

        [Then(@"the bonus points should include '(.*)'")]
        public void ThenTheBonusPointsShouldInclude(string expectedBonusPoints)
        {
            string actualBonusPoints = jobDescriptionPage.GetJobBonusPoints();
            Assert.IsTrue(actualBonusPoints.Contains(expectedBonusPoints));
        }

        [Then(@"the job offers should include:")]
        public void ThenTheJobOffersShouldInclude(Table table)
        {
            List<string> expectedJobOffers = table.Rows.Select(row => row["Offer"]).ToList();
            List<string> actualJobOffers = jobDescriptionPage.GetJobOffers();
            CollectionAssert.AreEqual(expectedJobOffers, actualJobOffers);
        }

        [When(@"I click the Apply button")]
        public void WhenIClickTheApplyButton()
        {
            jobDescriptionPage.ClickApplyButton();
            string originalWindow = driver.CurrentWindowHandle;
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.Close();
                    driver.SwitchTo().Window(window);
                }
            }
        }

        [Then(@"I decline the legal notice")]
        public void ThenIDeclineTheLegalNotice()
        {
            loginPage.DeclineLegalNotice();
        }

        [Then(@"I return to the Careers home")]
        public void ThenIReturnToTheCareersHome()
        {
            loginPage.ReturnToCareersHome();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
