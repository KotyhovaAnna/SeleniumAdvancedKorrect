using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
namespace NUnitTestProjectSeleniumWebDriverAdvanced
{
    class AddProductPage
    {
        private IWebDriver driver;



        public AddProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement searchAll_Products => driver.FindElement(By.XPath("//a[contains(text(), 'All Products')]"));
        private IWebElement SearchCreateNew => driver.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
        private IWebElement searchProductName => driver.FindElement(By.XPath("//input[@name='ProductName'] "));
        private IWebElement searchCategoryId => driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@value][text()=\"Produce\"]"));
        private IWebElement SearchSupplierId => driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@value][text()=\"Mayumi's\"]"));
        private IWebElement searchUnitPrice => driver.FindElement(By.XPath("//input[@id = 'UnitPrice']"));
        private IWebElement searchQuantityPerUnit => driver.FindElement(By.XPath("//input[@id = 'QuantityPerUnit']"));
        private IWebElement searchUnitsInStock => driver.FindElement(By.XPath("//input[@id = 'UnitsInStock']"));
        private IWebElement searchUnitsOnOrder => driver.FindElement(By.XPath("//input[@id = 'UnitsOnOrder']"));
        private IWebElement searchReorderLevel => driver.FindElement(By.XPath("//input[@id = 'ReorderLevel']"));
        private IWebElement searchsubmit => driver.FindElement(By.XPath("//*[@type='submit']"));

        private IWebElement nameNewProduct => driver.FindElement(By.XPath("//td[contains(a,'морс')]/a"));

        public AddProductPage AddNewProduct()
        {
            new Actions(driver).Click(searchAll_Products).Build().Perform();
            new Actions(driver).Click(SearchCreateNew).Build().Perform();
            new Actions(driver).SendKeys(searchProductName, "морс").Build().Perform();
            driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@value][text()=\"Produce\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@value][text()=\"Mayumi's\"]")).Click();
            new Actions(driver).Click(searchUnitPrice).SendKeys("30").Build().Perform();
            new Actions(driver).Click(searchQuantityPerUnit).SendKeys("95").Build().Perform();
            new Actions(driver).Click(searchUnitsInStock).SendKeys("9").Build().Perform();
            new Actions(driver).Click(searchUnitsOnOrder).SendKeys("74").Build().Perform();
            new Actions(driver).Click(searchReorderLevel).SendKeys("8").Build().Perform();
            new Actions(driver).Click(searchsubmit).Build().Perform();


            return this;
        }


        public string AssertAddNewProducts()
        {
            return nameNewProduct.Text;
        }
    }
}