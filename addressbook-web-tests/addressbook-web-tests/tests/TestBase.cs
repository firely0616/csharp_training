using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));

        }

        public static Random random = new Random();

        public static string GenerateRandomString(int max) 
        {
            int l = Convert.ToInt32(random.NextDouble() * max);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<l; i++)
            {
                sb.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 65)));
            }
            return sb.ToString();

        }



    }
}
