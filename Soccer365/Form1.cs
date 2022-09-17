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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer365
{
    public partial class Form1 : Form
    {
        private delegate DialogResult ShowOpenFileDialogInvoker();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchInTxt("Команда");
        }

        private void SearchInTxt(string keyWord)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            ShowOpenFileDialogInvoker invoker = new ShowOpenFileDialogInvoker(openFile.ShowDialog);

            this.Invoke(invoker);

            if (openFile.FileName != "")
            {
                string filename = openFile.FileName;
                string str = File.ReadAllText(filename);

                var kek = str.Split(new Char[] { ':', ',','\n' }).ToList();

                foreach (string s in kek)
                {
                    if (s.Trim() != "" && Regex.IsMatch(s, keyWord))
                    {
                        var text = kek[kek.IndexOf(keyWord) + 1] + " " + kek[kek.IndexOf(keyWord) + 3];
                        break;
                    }
                }
            }

               
        }
        void Btn_Soccer365_Click(object sender, EventArgs e)
        {
            int o = 12;
            
            IWebDriver driver = new ChromeDriver();

            while (o < 800)
            {
                if (o == 19) o=418;

                try
                {
                    driver.Url = $@"https://soccer365.ru/competitions/{o}/";

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
                            continue;
                        }


                        int game = 1;
                        int defeats = 4;
                        int scored = 5;
                        int conceded = 6;

                        try
                        {
                            for (int y = 2; y < 21; y++)
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
                }
                catch
                {
                    o++;
                    continue;
                }
                o++;
            }     

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmB_years_game.SelectedIndex = 0;
            cmB_years_game_catch.SelectedIndex = 0;
            cmB_name_game.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 12;
            IWebDriver driver = new ChromeDriver();

            while (k < 800)
            {
                if (k == 19) k = 418;

                try
                {
                    driver.Url = $@"https://soccer365.ru/competitions/{k}/";

                    var cmd2 = "2022";
                    var i = 0;
                    cmB_years_game.SelectedIndex = 0;

                    while (i < cmB_years_game_catch.Items.Count)
                    {
                        Setting.GetInstance.CheckingFileAvailability(cmB_years_game_catch.Text);

                        try
                        {

                            driver.FindElement(By.XPath($"//span[@class='selectbox-label'][contains(.,'{cmd2}')]")).Click();

                            driver.FindElement(By.XPath($"//a[contains(.,'{cmB_years_game_catch.Text}')]")).Click();

                            cmd2 = cmB_years_game_catch.Text;
                        }
                        catch
                        {
                            if (i < cmB_years_game_catch.Items.Count - 1) cmB_years_game_catch.SelectedIndex = i + 1;
                            i++;
                            continue;
                        }


                        int game = 1;
                        int defeats = 4;
                        int scored = 5;
                        int conceded = 6;

                        try
                        {
                            for (int y = 2; y < 21; y++)
                            {
                                var Team = $"{driver.FindElement(By.XPath($"(//a[@rel='nofollow'])[{y}]")).GetAttribute("textContent")}\r\n";// Записываем команду

                                string playGame = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{game}]")).GetAttribute("textContent")}\r\n";

                                string playDefeats = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{defeats}]")).GetAttribute("textContent")}\r\n";

                                string goalsScored = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{scored}]")).GetAttribute("textContent")}\r\n";

                                string goalsСonceded = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{conceded}]")).GetAttribute("textContent")}\r\n";

                                Team team = new Team(Team, playGame, playDefeats, goalsScored, goalsСonceded);
                                team.PrintTeam(cmB_years_game_catch.Text);
                                game += 8;
                                defeats += 8;
                                scored += 8;
                                conceded += 8;
                            }
                        }
                        catch
                        {

                        }

                        if (i < cmB_years_game_catch.Items.Count - 1) cmB_years_game_catch.SelectedIndex = i + 1;
                        i++;
                    }
                }
                catch
                {
                    k++;
                    continue;
                }
                k++;
            }
        }

    }

}
