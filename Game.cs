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

        public Game() 
        {
            this.team1 = null;
            this.team2 = null;
            team1Score = 0;
            team2Score = 0;
        }

        public Game(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            team1Score = 0;
            team2Score = 0;
        }

        public Game(string team1, string team2, int team1Score, int team2Score)
        {
            if (team1 == null || team2 == null)
            {
                throw new NullReferenceException();
            }
            if(team1Score < 0 || team2Score < 0)
            {
                throw new InvalidOperationException();
            }
            this.team1 = team1;
            this.team2 = team2;
            this.team1Score = team1Score;
            this.team2Score = team2Score;
            this.key = team1 + team2;
        }
    }

}
