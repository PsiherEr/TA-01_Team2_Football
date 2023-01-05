using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_01_Team2_Football
{
    public class Scoreboard
    {
        public List<Game> games;
        public Scoreboard()
        {
            games = new List<Game>();
        }
        private static int CompareListByDecreasing(Game game1,Game game2)
        {
            if ((game1.team1Score + game1.team2Score)<(game2.team1Score + game2.team2Score))
            {
                return 1;
            }
            else if ((game1.team1Score + game1.team2Score) == (game2.team1Score + game2.team2Score))
            {
                return 0;
            }
            else if ((game1.team1Score + game1.team2Score)>(game2.team1Score + game2.team2Score))
            {
                return -1;
            }
            return 0;
        }
        public List<Game> sortScoreBoard()
        {
            if(games.Count <= 1)
            {
                throw new IndexOutOfRangeException();
            }
            games.Sort(CompareListByDecreasing);

            return games; 
        }
    }
}