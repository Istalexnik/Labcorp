using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabcorpProject.POM
{
    public class JobDescriptionPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public JobDescriptionPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public IWebElement JobTitle => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("job-title")));
        public IWebElement JobLocation => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("job-location")));
        public IWebElement JobId => wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("jobId")));
        public IWebElement JobRequirements => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[b/u[text()='Requirements:']]/following-sibling::ul/li[1]/p/span")));
        public IWebElement BonusPoints => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[b/u[text()='Bonus Points if you have:']]/following-sibling::ul/li[1]/p/span")));
        public IReadOnlyCollection<IWebElement> JobOffers => wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//p[b/u[text()='What we offer:']]/following-sibling::ul[1]/li")));


        public string GetJobTitle()
        {
            return JobTitle.Text;
        }

        public string GetJobLocation()
        {
            return JobLocation.Text.Replace("Location", "").Trim();
        }

        public string GetJobId()
        {
            return JobId.Text.Replace("Job Id :", "").Trim();
        }

        public string GetJobRequirements()
        {
            return JobRequirements.Text;
        }

        public string GetJobBonusPoints()
        {
            return BonusPoints.Text;
        }

        public List<string> GetJobOffers()
        {
            return JobOffers.Select(offer => offer.Text).ToList();
        }

        public void ClickApplyButton()
        {
            driver.FindElement(By.CssSelector("[data-ph-at-id *= 'apply-text']")).Click();
        }
    }
}
