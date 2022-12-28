using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_01_Team2_Football
{
    public class Game
    {
        public string team1;
        public string team2;
        public int team1Score;
        public int team2Score;
        public string key;

        private Game() { }

        public Game(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            team1Score = 0;
            team2Score = 0;
        }
    }
    
}
