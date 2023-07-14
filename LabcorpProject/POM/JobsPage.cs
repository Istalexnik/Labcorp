using OpenQA.Selenium;

namespace LabcorpProject.POM
{
    internal class JobsPage
    {        
        private readonly IWebDriver driver;

        public JobsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement JobLink(string jobTitle) => driver.FindElement(By.LinkText(jobTitle));

        public void SelectJob(string jobTitle)
        {
            JobLink(jobTitle).Click();
        }
    }
}
