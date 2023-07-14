using OpenQA.Selenium;

namespace LabcorpProject.POM
{
    internal class CareersPage
    {
        private IWebDriver driver;
        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement JobSearchBox => driver.FindElement(By.Id("typehead"));

        public void SearchForJob(string jobTitle)
        {
            JobSearchBox.SendKeys(jobTitle + Keys.Down + Keys.Enter);
        }
    }
}
