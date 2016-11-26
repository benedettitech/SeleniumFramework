using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumFramework
{
    public static class SeleniumFramework
    {
        //Login with arguments

        public static void Login(Uri environment, string username, string password)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Libraries\");
            driver.Navigate().GoToUrl(environment);
            driver.SwitchTo().Frame("gsft_main");
            driver.FindElement(By.Name("user_name")).Click();
            driver.FindElement(By.Id("user_name")).Clear();
            driver.FindElement(By.Id("user_name")).SendKeys(username);
            driver.FindElement(By.Id("user_password")).Clear();
            driver.FindElement(By.Id("user_password")).SendKeys(password);
            driver.FindElement(By.Id("sysverb_login")).Click();
            driver.Close();
        }

        private static IWebDriver InternalLogin(Uri environment, string username, string password)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Libraries\");
            driver.Navigate().GoToUrl(environment);
            driver.SwitchTo().Frame("gsft_main");
            driver.FindElement(By.Name("user_name")).Click();
            driver.FindElement(By.Id("user_name")).Clear();
            driver.FindElement(By.Id("user_name")).SendKeys(username);
            driver.FindElement(By.Id("user_password")).Clear();
            driver.FindElement(By.Id("user_password")).SendKeys(password);
            driver.FindElement(By.Id("sysverb_login")).Click();
            return driver;
        }

        //Create Incident with arguments

        public static void CreateIncident(Uri environment, string username, string password)
        {
            IWebDriver driver = InternalLogin(environment, username, password);
            driver.FindElement(By.LinkText("Incidents")).Click();
            driver.SwitchTo().Frame("gsft_main");
            driver.FindElement(By.Id("new_incident")).Click();
            SelectElement urgency = new SelectElement(driver.FindElement(By.Name("IO:5a33d0ef0a0a0b9b007b906f6c589c57")));
            urgency.SelectByText("1 - High");
            driver.FindElement(By.Name("IO:3f272c500a0a0b990059c24380a2bc02")).SendKeys("Creating a test incident.");
            driver.FindElement(By.Id("submit_button")).Click();
            driver.Close();
        }

        public static void CreateIncidentAsSuperUser(Uri environment, string username, string password)
        {
            IWebDriver driver = InternalLogin(environment, username, password);
            driver.FindElement(By.LinkText("Incidents")).Click();
            driver.SwitchTo().Frame("gsft_main");
            driver.FindElement(By.Id("sysverb_new")).Click();
            SelectElement urgency = new SelectElement(driver.FindElement(By.Name("incident.urgency")));
            urgency.SelectByText("1 - High");
            driver.FindElement(By.Name("incident.short_description")).SendKeys("Creating a test incident.");
            driver.FindElement(By.Id("sysverb_insert")).Click();
            driver.Close();
        }

    }
}
