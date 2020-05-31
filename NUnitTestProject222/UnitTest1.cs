using NUnit.Framework;
using NUnitTestProjectSeleniumWebDriverAdvanced;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace NUnitTestProjectAnya
{
    public class Tests
    {

        private IWebDriver driver;
        private AddProductPage addProductPage;
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        protected const string name = "user";
        protected const string password = "user";
        private const string CheckLoginPage = "Home page";
        private const string CheckAddProductPage = "CreateNew";
        private const string CheckLogout = "Login";



        [OneTimeSetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            AddProductPage addProductPage = loginPage.LoginMetod(name, password);

        }

        [Test, Order(1)]

        public void Login()
        {
            Assert.AreEqual(CheckLoginPage, loginPage.AssertLogin());
        }

        [Test, Order(2)]

        public void NewProduct()
        {
            AddProductPage addProductPage = new AddProductPage(driver);
            addProductPage.AddNewProduct();
            Assert.AreEqual(CheckAddProductPage, addProductPage.AssertAddNewProducts());
        }

        [Test, Order(3)]

        public void Logout()
        {
            logoutPage = new LogoutPage(driver);
            logoutPage.Logout();

            Assert.AreEqual(CheckLogout, logoutPage.AssertLogout());
        }


        [OneTimeTearDown]

        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

    }
}