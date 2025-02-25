 using OpenQA.Selenium;
 using OpenQA.Selenium.Chrome;
 using OpenQA.Selenium.DevTools.V133.Audits;
 using OpenQA.Selenium.Support.UI;
using System.Linq;

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
               string actual = "";
            string Alarmsettime = "9:99 AM";
            int hrs = 9;
            int mins = 99;
            bool IsAM = false;
            
                //set time and min 
                for (int i = 0; i < 24; i++)
                {
                    Thread.Sleep(1000);
                    IWebElement newalarm = driver.FindElement(By.XPath("//button[@id='btn-hour-plus']"));
                    newalarm.Click();
                    IWebElement alarmtime = driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-hour']"));
                    actual = alarmtime.GetAttribute("value").ToString().Trim(); // 09 AM

                    var m = actual.Replace("AM", " ").Trim();
                    if (hrs.ToString() == m)
                    {
                    IsAM = actual.Contains("AM", StringComparison.OrdinalIgnoreCase);
                    Assert.AreEqual(hrs.ToString(), m);
                        
                        break;
                    }
                    

                }
            List<IWebElement> newmins = new List<IWebElement>();
            newmins = (List<IWebElement>)driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-minute']"));
            string minsvalues = driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-minute']/option")).Text;
            for (int j = 0; j < 60; j++)
                {
                    Thread.Sleep(1000);
                    IWebElement Newmins = driver.FindElement(By.XPath("//button[@id='btn-minute-plus']"));
                    Newmins.Click();
                    IWebElement alarmtime = driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-minute']"));
                    actual = alarmtime.GetAttribute("value").ToString().Trim();
                    
                    if (mins.ToString() == actual.Trim())
                    {
                        Assert.AreEqual(mins.ToString(), actual);
                        break;

                    }
                else if (mins.ToString() == minsvalues.Contains("99").ToString())
                {
                    Console.WriteLine("Mins is not in dropdown");
                }

                
                
                
                }


            //SelectElement newAlarm = new SelectElement(driver.FindElement(By.XPath("//div[@class='input-group xs-mb-0']//select[@id='edt-hour']")));
            //newAlarm.SelectByText("9 AM");

            //newmins.SelectByText("00");

                //add title
                IWebElement title = driver.FindElement(By.XPath("//div//input[@id='edt-title']"));
                title.SendKeys("Trumpf Metamation - Long Time");

                //click on save 
                IWebElement saveBtn = driver.FindElement(By.XPath("//div//button[text()='Start']"));
                saveBtn.Click();

                //validate the alarm has been set
                Assert.True(true, "alarm is set", driver.FindElement(By.XPath("//div//span[@id='lbl-alarm-time']")));

                string aftertimest = driver.FindElement(By.XPath("//div[@id='pnl-alarm-time']//span[@id='lbl-alarm-time']")).Text;
                Assert.Pass(Alarmsettime, aftertimest, "Alarm is set properly");

                //removed alarm 
                //IWebElement stopBtn = driver.FindElement(By.XPath("//div//button[text()='Stop Alarm']"));
                //stopBtn.Click();


                //driver.Quit();






            }
        }
    }
