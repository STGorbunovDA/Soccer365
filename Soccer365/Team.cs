using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer365
{
    internal class Team
    {
        public string Name { get; set; } // имя

        public string PlayGame { get; set; } // кол-во игр

        public string PlayDefeats { get; set; } // кол-во поражений

        public double PercentWin { get; set; } // процент выйгрыша

        public double GoalsScoredPlay { get; set; } // кол-во голов забито

        public double GoalsСoncededPlay { get; set; } // кол-во голов пропущено


        public Team(string name, string playGame, string playDefeats, string goalsScored, string goalsСonceded)
        {
            Name = name;
            PlayGame = playGame;
            PercentWin = (100 - (Convert.ToDouble(playDefeats) / Convert.ToDouble(playGame)) * 100);
            GoalsScoredPlay = Convert.ToDouble(goalsScored) / Convert.ToDouble(playGame);
            GoalsСoncededPlay = Convert.ToDouble(goalsСonceded) / Convert.ToDouble(playGame);
        }   
    }
}
