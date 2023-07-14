using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabcorpProject.POM
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public IWebElement DeclineLegalNoticeButton => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[data-automation-id='legalNoticeDeclineButton']")));
        public IWebElement CareersHomeButton => driver.FindElement(By.CssSelector("button[data-automation-id='navigationItem-Careers Home']"));


        public void DeclineLegalNotice()
        {
            DeclineLegalNoticeButton.Click();
        }

        public void ReturnToCareersHome()
        {
            CareersHomeButton.Click();
        }

    }
}
