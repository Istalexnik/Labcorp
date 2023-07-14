using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabcorpProject.POM
{
    internal class HomePage
    {
        private IWebDriver driver;
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        public IWebElement CloseBtn => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#onetrust-close-btn-container > button")));
        public IWebElement CareersLink => driver.FindElement(By.XPath("//a[text()='Careers']"));

        public void CloseCookieBanner()
        {
            CloseBtn.Click();
        }

        public void GoToCareers()
        {
            CareersLink.Click();
        }
    }
}
