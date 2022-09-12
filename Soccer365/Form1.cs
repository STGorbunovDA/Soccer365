using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (cmB_years_game.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = @"https://soccer365.ru/";

                driver.FindElement(By.XPath("(//a[@id='hds_item_link'])[3]")).Click();
                driver.FindElement(By.XPath("(//span[@class='selectbox-label'])[1]")).Click();
                driver.FindElement(By.XPath("(//a[@href='javascript:void(0)'])[2]")).Click();
                await Task.Delay(1000);
                driver.FindElement(By.XPath("//span[contains(.,'А-лига')]")).Click();
                //a[contains(.,'')]
                driver.FindElement(By.XPath("//span[@class='selectbox-label'][contains(.,'2022/2023')]")).Click();
                driver.FindElement(By.XPath($"//a[contains(.,'{cmB_years_game.Text}')]")).Click();

                int game = 1;
                int defeats = 4;

                for (int i = 2; i < 14; i++)
                {
                    var lbl_Team = $"{driver.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[{i}]")).GetAttribute("textContent")}\r\n";// Записываем команду

                    string playGameString = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{game}]")).GetAttribute("textContent")}\r\n";

                    string playDefeatsString = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{defeats}]")).GetAttribute("textContent")}\r\n";

                    double lbl_Percent = (100 - (Convert.ToDouble(playDefeatsString) / Convert.ToDouble(playGameString)) * 100);
                    if(lbl_Percent > 80) _dict[lbl_Team] = lbl_Percent;
                    game += 8;
                    defeats += 8;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                    {
                        string note = string.Empty;

                        note += $"Команда\t\tПроцент побед и ничей";

                        sw.WriteLine(note);

                        foreach (var pair in _dict)
                        {               
                            sw.Write($"{pair.Value} = {pair.Key}");    
                        }
                        MessageBox.Show("Файл успешно сохранен");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmB_years_game.SelectedIndex = 1;
        }
    }
}
