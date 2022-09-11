using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer365
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> _dict;
        public Form1()
        {
            InitializeComponent();
            _dict = new Dictionary<string, double>();
        }

        async void btn_Soccer365_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://soccer365.ru/";

            driver.FindElement(By.XPath("(//a[@id='hds_item_link'])[3]")).Click();
            driver.FindElement(By.XPath("(//span[@class='selectbox-label'])[1]")).Click();
            driver.FindElement(By.XPath("(//a[@href='javascript:void(0)'])[2]")).Click();
            await Task.Delay(1000);
            driver.FindElement(By.XPath("//span[contains(.,'А-лига')]")).Click();
            driver.FindElement(By.XPath("//span[@class='selectbox-label'][contains(.,'2022/2023')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'2021/2022')]")).Click();

            int game = 1;
            int defeats = 4;
            for (int i = 1; i < 13; i++)
            {
                var lbl_Team = $"{driver.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[{i}]")).GetAttribute("textContent")}\r\n";// Записываем команду

                string playGameString = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{game}]")).GetAttribute("textContent")}\r\n";

                string playDefeatsString = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{defeats}]")).GetAttribute("textContent")}\r\n";

                double lbl_Percent = (100 - (Convert.ToDouble(playDefeatsString) / Convert.ToDouble(playGameString)) * 100);

                _dict[lbl_Team] = lbl_Percent;
                game += 8;
                defeats += 8;
            }

            var result = string.Empty;

            foreach (var pair in _dict)
            {
                result += $"{pair.Key}={pair.Value}\r\n";
            }
            MessageBox.Show(result);

        }


    }
}
