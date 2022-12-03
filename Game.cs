using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_01_Team2_Football
{
    public class Game
    {
        public string team1 { get; }
        public string team2 { get; }
        public int team1Score { get; }
        public int team2Score { get; }

        private Game() { }

        public Game(string name1, string name2, int score1, int score2)
        {
            team1 = name1;
            team2 = name2;
            team1Score = score1;
            team2Score = score2;
        }
    }
    
}
