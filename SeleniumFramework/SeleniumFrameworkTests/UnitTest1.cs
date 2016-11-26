using System;
using SeleniumFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace SeleniumFrameworkTests
{
    [TestClass]
    public class UnitTest1
    {
        private Uri environment = new Uri(ConfigurationManager.AppSettings["environment"]);
        private string username = ConfigurationManager.AppSettings["username"];
        private string password = ConfigurationManager.AppSettings["password"];
        private string superusername = ConfigurationManager.AppSettings["superusername"];
        private string superuserpassword = ConfigurationManager.AppSettings["superuserpassword"];


        [TestMethod]
        public void LoginAsUser()
        {
            SeleniumFramework.SeleniumFramework.Login(environment, username, password);
        }

        [TestMethod]
        public void LoginAsSuperUser()
        {
            SeleniumFramework.SeleniumFramework.Login(environment, superusername, superuserpassword);
        }

        [TestMethod]
        public void CreateIncidentAsUser()
        {
            SeleniumFramework.SeleniumFramework.CreateIncident(environment, username, password);
        }

        [TestMethod]
        public void CreateIncidentAsSuperUser()
        {
            SeleniumFramework.SeleniumFramework.CreateIncidentAsSuperUser(environment, superusername, superuserpassword);
        }
    }
}
