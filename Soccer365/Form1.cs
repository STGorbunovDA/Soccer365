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
        public Form1()
        {
            InitializeComponent();
        }

        void Btn_Soccer365_Click(object sender, EventArgs e)
        {

            IWebDriver driver = new ChromeDriver();
            var z = 0;

            while (z < cmB_name_game.Items.Count)
            {
                driver.Url = $@"https://soccer365.ru/competitions/{cmB_name_game.Text}/";

                var cmd = "2022/2023";
                var i = 0;
                cmB_years_game.SelectedIndex = 0;
                while (i < cmB_years_game.Items.Count)
                {
                    Setting.GetInstance.CheckingFileAvailability(cmB_years_game.Text);

                    try
                    {
                        driver.FindElement(By.XPath($"//span[@class='selectbox-label'][contains(.,'{cmd}')]")).Click();

                        driver.FindElement(By.XPath($"//a[contains(.,'{cmB_years_game.Text}')]")).Click();
                        cmd = cmB_years_game.Text;

                    }
                    catch
                    {
                        if (i < cmB_years_game.Items.Count - 1) cmB_years_game.SelectedIndex = i + 1;
                        i++;
                    }


                    int game = 1;
                    int defeats = 4;
                    int scored = 5;
                    int conceded = 6;

                    try
                    {
                        for (int y = 2; y < 20; y++)
                        {
                            var Team = $"{driver.FindElement(By.XPath($"(//a[@rel='nofollow'])[{y}]")).GetAttribute("textContent")}\r\n";// Записываем команду

                            string playGame = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{game}]")).GetAttribute("textContent")}\r\n";

                            string playDefeats = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{defeats}]")).GetAttribute("textContent")}\r\n";

                            string goalsScored = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{scored}]")).GetAttribute("textContent")}\r\n";

                            string goalsСonceded = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{conceded}]")).GetAttribute("textContent")}\r\n";

                            Team team = new Team(Team, playGame, playDefeats, goalsScored, goalsСonceded);
                            team.PrintTeam(cmB_years_game.Text);
                            game += 8;
                            defeats += 8;
                            scored += 8;
                            conceded += 8;
                        }
                    }
                    catch
                    {

                    }

                    if (i < cmB_years_game.Items.Count - 1) cmB_years_game.SelectedIndex = i + 1;
                    i++;
                }




                if (z < cmB_name_game.Items.Count - 1) cmB_name_game.SelectedIndex = z + 1;
                z++;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmB_years_game.SelectedIndex = 0;
            cmB_years_game_catch.SelectedIndex = 0;
            cmB_name_game.SelectedIndex = 0;
        }
    }

}
