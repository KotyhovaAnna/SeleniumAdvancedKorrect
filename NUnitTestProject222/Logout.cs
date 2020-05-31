using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
namespace NUnitTestProjectSeleniumWebDriverAdvanced
{
    class LogoutPage
    {
        private IWebDriver driver;

        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement searchLogout => driver.FindElement(By.XPath("//a[@href= '/Account/Logout']"));
        private IWebElement assertLogout => driver.FindElement(By.XPath("//div[h2= 'Login']"));
        public void Logout()
        {
            new Actions(driver).Click(searchLogout).Build().Perform();
        }
        public string AssertLogout()
        {
            return assertLogout.Text;
        }
    }
}
