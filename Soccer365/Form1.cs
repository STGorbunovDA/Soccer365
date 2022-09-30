using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
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
        void Btn_Soccer365_Click(object sender, EventArgs e)
        {
            int o = 12;
            int colTeam = 1;
            IWebDriver driver = new ChromeDriver();

            while (o < 800)
            {
                if (o == 19) o = 418;

                try
                {
                    driver.Url = $@"https://soccer365.ru/competitions/{o}/";

                    var cmd = "2022";
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
                            for (int y = 1; y < 21; y++)
                            {
                                var Team = $"{driver.FindElement(By.XPath($"(//a[@rel='nofollow'])[{y}]")).GetAttribute("textContent")}\r\n";// Записываем команду

                                string playGame = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{game}]")).GetAttribute("textContent")}\r\n";

                                string playDefeats = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{defeats}]")).GetAttribute("textContent")}\r\n";

                                string goalsScored = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{scored}]")).GetAttribute("textContent")}\r\n";

                                string goalsСonceded = $"{driver.FindElement(By.XPath($"(//td[@class='ctr'])[{conceded}]")).GetAttribute("textContent")}\r\n";

                                Team team = new Team(Team, playGame, playDefeats, goalsScored, goalsСonceded);

                                if (team.PercentWin > Convert.ToInt32(cmB_Percentage_draw.Text))
                                {
                                    var fileName = $"C:\\Soccer\\КомандаТочно\\Команды процент побед и ничей более {cmB_Percentage_draw.Text}.txt";
                                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
                                    {
                                        sw.Write($"Команда{colTeam}: {team.Name.Trim()},\nПроцент побед: {team.PercentWin},\nЗабивают за матч: {team.GoalsScoredPlay},\nПропускают за матч: {team.GoalsСoncededPlay}\n-------------------\n");
                                    }
                                    colTeam++;
                                }
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
            MessageBox.Show("Готовченко_1");
            try
            {
                string filename = $"C:\\Soccer\\КомандаТочно\\Команды процент побед и ничей более {cmB_Percentage_draw.Text}.txt";
                string str = File.ReadAllText(filename);

                int counter = 0;

                var sSearch = "";
                var i = 0;
                var countSearchSlovo = 1;//для поиска по ключевому слову команды

                var kek = str.Split(new Char[] { ':', ',', '\n' }).ToList();

                while (i < kek.Count)
                {
                    string keyWord = $"Команда{countSearchSlovo}";

                    foreach (string s in kek)
                    {
                        if (s.Trim() != "" && Regex.IsMatch(s, keyWord))
                        {
                            sSearch = kek[kek.IndexOf(keyWord) + 1];
                            break;
                        }
                    }
                    if (sSearch != "")
                    {
                        foreach (var word in kek)
                        {
                            if (sSearch == word)
                                counter++;
                        }

                        if (counter > Convert.ToInt32(cmb_Occurs_more.Text))
                        {
                            if (!Directory.Exists($"C:\\Soccer\\КомандаТочно\\"))
                            {
                                Directory.CreateDirectory($"C:\\Soccer\\КомандаТочно\\");
                            }

                            var fileName = $"C:\\Soccer\\КомандаТочно\\команды в чемпионате не проигрывали более {cmb_Occurs_more.Text} раз.txt";
                            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
                            {
                                sw.Write($"{sSearch}\n");
                            }

                        }
                        countSearchSlovo++;
                        counter = 0;
                        i++;
                        sSearch = "";
                    }
                    else break;
                }
                MessageBox.Show("Готовченко_2");

                try
                {
                    string filename2 = $"C:\\Soccer\\КомандаТочно\\команды в чемпионате не проигрывали более {cmb_Occurs_more.Text} раз.txt";
                    string str2 = File.ReadAllText(filename2);

                    var dest = Setting.GetInstance.WordsDistinct(str2);

                    if (!Directory.Exists($"C:\\Soccer\\КомандаТочно\\Без повторов"))
                    {
                        Directory.CreateDirectory($"C:\\Soccer\\КомандаТочно\\Без повторов");
                    }

                    var fileName = $"C:\\Soccer\\Команды.txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
                    {
                        sw.Write($"{dest}");
                    }
                    MessageBox.Show("Готовченко_3");

                    string dirName = $"C:\\Soccer\\КомандаТочно";
                    if (Directory.Exists(dirName))
                    {
                        Directory.Delete(dirName, true);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Отсутсвует файл!2");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Отсутсвует файл!1");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmB_years_game.SelectedIndex = 0;
            cmB_Percentage_draw.SelectedIndex = 1;
            cmb_Occurs_more.SelectedIndex = 2;
        }

        private void Bnt_PlayGameToday_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            ShowOpenFileDialogInvoker invoker = new ShowOpenFileDialogInvoker(openFile.ShowDialog);

            this.Invoke(invoker);

            if (openFile.FileName != "")
            {
                try
                {
                    string filename = openFile.FileName;
                    string text = File.ReadAllText(filename);

                    cmb_Team.Items.AddRange(File.ReadAllLines(filename, System.Text.Encoding.Default));
                    cmb_Team.SelectedIndex = 0;
                    lbl_colTeam.Text += " " + cmb_Team.Items.Count.ToString();
                    if (cmb_Team.Items.Count > 0)
                    {
                        btn_Show_team_games_today.Visible = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удаётся загрузить игры");
                }

            }
        }

        private async void Btn_Show_team_games_today_Click(object sender, EventArgs e)
        {
            IWebDriver driver2 = new ChromeDriver();
            driver2.Url = $@"https://soccer365.ru/online/";
            driver2.FindElement(By.XPath($"//span[@class='tabs_item js'][contains(.,'Все игры')]")).Click();

            var i = 0;
            string win = "";
            string draw = "";
            string defeat = "";

            while (i < cmb_Team.Items.Count)
            {
                try
                {
                    DateTime today1 = DateTime.Today;
                    var today = today1.ToString("dd.MM.yyyy");
                    var teamSearch = $"{driver2.FindElement(By.XPath($"//span[contains(.,'{cmb_Team.Text.Trim()}')]")).GetAttribute("textContent")}";
                    #region метод получения кефов
                    //try
                    //{
                    //    driver2.FindElement(By.XPath($"//div[@class='at'][contains(.,'{cmb_Team.Text}					-')]")).Click();//не находит команду
                    //    driver2.FindElement(By.XPath($"(//a[contains(.,'Ставки')])[1]")).Click();  

                    //    win = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[10]")).GetAttribute("textContent")}";
                    //    draw = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[11]")).GetAttribute("textContent")}";
                    //    defeat = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[12]")).GetAttribute("textContent")}";

                    //}
                    //catch
                    //{
                    //    driver2.FindElement(By.XPath($"//div[@class='ht'][contains(.,'{cmb_Team.Text}-')]")).Click();//не находит команду
                    //    driver2.FindElement(By.XPath($"(//a[contains(.,'Ставки')])[1]")).Click();

                    //    win = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[10]")).GetAttribute("textContent")}";
                    //    draw = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[11]")).GetAttribute("textContent")}";
                    //    defeat = $"{driver2.FindElement(By.XPath($"(//a[contains(@rel,'nofollow')])[12]")).GetAttribute("textContent")}";
                    //}
                    #endregion
                    var fileName = $"C:\\Soccer\\Сегодня играют {today}.txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
                    {
                        sw.Write($"{teamSearch}\n");
                        //sw.Write($"{teamSearch}\nПобеда1 кеф:{win}\nНичья кеф:{draw}\nПобеда2 кеф:{defeat}\n-----------------------\n");
                    }
                    win = "";
                    draw = "";
                    defeat = "";
                    if (i < cmb_Team.Items.Count - 1) cmb_Team.SelectedIndex = i + 1;

                    //driver2.FindElement(By.XPath($"//a[contains(.,'Футбол онлайн')]")).Click();
                    //driver2.FindElement(By.XPath($"//span[@class='tabs_item js'][contains(.,'Все игры')]")).Click();

                }
                catch
                {
                    if (i < cmb_Team.Items.Count - 1) cmb_Team.SelectedIndex = i + 1;
                    i++;
                }

                i++;
            }
            DateTime tomorrow1 = DateTime.Today.AddDays(1);

            var tomorrow = tomorrow1.ToString("dd");

            try
            {
                var re = new Regex("0");
                tomorrow = re.Replace(tomorrow, "");
            }
            catch
            {

            }  
            await Task.Delay(2000);
            driver2.FindElement(By.XPath($"//span[@class='icon16']")).Click();
            driver2.FindElement(By.XPath($"//span[@class='flatpickr-day '][contains(.,'{tomorrow}')]")).Click();
            
            var zp = 0;

            while (zp < cmb_Team.Items.Count)
            {
                try
                {
                    DateTime tomorrow2 = DateTime.Today.AddDays(1);
                    var tomorrow3 = tomorrow2.ToString("dd.MM.yyyy");
                    var teamSearch = $"{driver2.FindElement(By.XPath($"//span[contains(.,'{cmb_Team.Text.Trim()}')]")).GetAttribute("textContent")}";
                   
                    var fileName = $"C:\\Soccer\\Завтра играют {tomorrow3}.txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
                    {
                        sw.Write($"{teamSearch}\n");
                    }
                    win = "";
                    draw = "";
                    defeat = "";

                    if (zp < cmb_Team.Items.Count - 1)
                    {
                        cmb_Team.SelectedIndex = zp + 1;
                    }

                }
                catch
                {
                    if (zp < cmb_Team.Items.Count - 1)
                    {
                        cmb_Team.SelectedIndex = zp + 1;
                    }
                    zp++;
                }

                zp++;
            }

            try
            {
                foreach (Process proc in Process.GetProcessesByName("chrome"))
                {
                    proc.Kill();
                }
            }
            catch
            {

            }
            try
            {
                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.Kill();
                }
            }
            catch
            {

            }
            MessageBox.Show("Готовченко!");
        }

        
    }

}
