 using OpenQA.Selenium;
 using OpenQA.Selenium.Chrome;
 using OpenQA.Selenium.DevTools.V133.Audits;
 using OpenQA.Selenium.Support.UI;

namespace TestProject1
    {
        public class Tests
        {

            [Test]
            [Description("Verify the Alarm is set and removed from the clock app")]
            public void Test1()
            {
                //open chromedriver
                IWebDriver driver = new ChromeDriver();

                //open clock app
                driver.Navigate().GoToUrl("https://vclock.com/");
                driver.Manage().Window.Maximize();

                //set new alarm 
                IWebElement Alarm = driver.FindElement(By.XPath("//div[@id='pnl-set-alarm']/button[text()='Set Alarm']"));
                Alarm.Click();


                //set time and min 
                for (int i = 0; i < 24; i++)
                {
                    Thread.Sleep(1000);
                    IWebElement newalarm = driver.FindElement(By.XPath("//button[@id='btn-hour-plus']"));
                    newalarm.Click();
                    IWebElement alarmtime = driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-hour']"));
                    string actual = alarmtime.GetAttribute("value").ToString().Trim();
                    string time = "9 PM";
                    if (time == actual)
                    {
                        Assert.AreEqual(time, actual);
                        break;
                    }
                    else
                    {
                        continue;
                    }


                }
                for (int j = 0; j < 60; j++)
                {
                    Thread.Sleep(1000);
                    IWebElement Newmins = driver.FindElement(By.XPath("//button[@id='btn-minute-plus']"));
                    Newmins.Click();
                    IWebElement alarmtime = driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-minute']"));
                    string actual = alarmtime.GetAttribute("value").ToString().Trim();
                    string time = "00";
                    if (time == actual)
                    {
                        Assert.AreEqual(time, actual);
                        break;

                    }
                    else
                    {
                        continue;
                    }

                }


                //SelectElement newAlarm = new SelectElement(driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-hour']")));
                //newAlarm.SelectByText("9 AM");

                //SelectElement newmins = new SelectElement(driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-minute']")));
                //newmins.SelectByText("00");

                //add title
                IWebElement title = driver.FindElement(By.XPath("//div//input[@id='edt-title']"));
                title.SendKeys("Trumpf Metamation - Long Time");

                //click on save 
                IWebElement saveBtn = driver.FindElement(By.XPath("//div//button[text()='Start']"));
                saveBtn.Click();

                //validate the alarm has been set
                Assert.True(true, "alarm is set", driver.FindElement(By.XPath("//div//span[@id='lbl-alarm-time']")));

                //removed alarm 
                IWebElement stopBtn = driver.FindElement(By.XPath("//div//button[text()='Stop Alarm']"));
                stopBtn.Click();


                driver.Quit();






            }
        }
    }
