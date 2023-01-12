using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public void input(string team1, string team2)
        {
            if (string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2))
            {
                throw new ArgumentException("Name is null or empty");
            }

            if (team1.ToLower() == team2.ToLower())
            {
                throw new ArgumentException("Same names of team");
            }

            Regex regex = new Regex(@"^[A-Z][a-z0-9]+$");
            MatchCollection matches1 = regex.Matches(team1);
            MatchCollection matches2 = regex.Matches(team2);
            if (matches1.Count == 0)
            {
                throw new ArgumentException("Unwanted symbols in team`s 1 name");
            }
            if (matches2.Count == 0)
            {
                throw new ArgumentException("Unwanted symbols in team`s 2 name");
            }

            for (int i = 0; i < games.Count(); i++)
            {
                if (team1 == games[i].team1 || team1 == games[i].team2)
                {
                    throw new ArgumentException("Team 1 is already playing");
                }
                if (team2 == games[i].team2 || team2 == games[i].team1)
                {
                    throw new ArgumentException("Team 2 is already playing");
                }
            }

            var game = new Game(team1, team2);
            games.Add(game);
        }
        
        public void finish(string team1, string team2)
        {
            if (string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2))
            {
                throw new ArgumentException("Name is null or empty");
            }

            if (team1.ToLower() == team2.ToLower())
            {
                throw new ArgumentException("Same names of team");
            }

            Regex regex = new Regex(@"^[A-Z][a-z0-9]+$");
            MatchCollection matches1 = regex.Matches(team1);
            MatchCollection matches2 = regex.Matches(team2);
            if (matches1.Count == 0)
            {
                throw new ArgumentException("Unwanted symbols in team`s 1 name");
            }
            if (matches2.Count == 0)
            {
                throw new ArgumentException("Unwanted symbols in team`s 2 name");
            }

            if (games.Count == 0)
            {
                throw new ArgumentException("No games");
            }

            for (int i = 0; i < games.Count(); i++)
            {
                if (team1 == games[i].team1 && team2 == games[i].team2)
                {
                    games.RemoveAt(i);
                }
                else
                {
                    throw new ArgumentException("Game does not exist");
                }
            }
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

        public void UpdateScore(Game game, int firstTeamScore, int secondTeamScore)
        {
            if (game == null)
            {
                throw new NullReferenceException("Game is null");
            }

            if (firstTeamScore < 0 || secondTeamScore < 0)
            {
                throw new InvalidOperationException();
            }

            if (Math.Abs(game.team1Score - firstTeamScore) > 1 || Math.Abs(game.team2Score - secondTeamScore) > 1)
            {
                throw new InvalidOperationException("Point cannot change by more than 1 point");
            }

            if ((Math.Abs(game.team1Score - firstTeamScore) + Math.Abs(game.team2Score - secondTeamScore)) > 1)
            {
                throw new InvalidOperationException("All score cannot change by more than 1 point");
            }

            game.team1Score = firstTeamScore;
            game.team2Score = secondTeamScore;
        }
    }
}