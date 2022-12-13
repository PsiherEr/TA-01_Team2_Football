namespace TA_01_Team2_Football.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void TestSummary()
        {
            Scoreboard scoreboard1 = new Scoreboard();
            Scoreboard testScoreboard = new Scoreboard();
            int CountGames = scoreboard1.games.Count();
            if (CountGames <= 1)
                Assert.True(true);
            testScoreboard = scoreboard1.sortScoreBoard();
            int temp = testScoreboard.games[0].team1Score + testScoreboard.games[0].team2Score;
            for (int i = 1; i < CountGames; i++)
            {
                if(temp < testScoreboard.games[i].team1Score + testScoreboard.games[i].team2Score)
                {
                    Assert.True(false);
                }
                temp -= temp - (testScoreboard.games[i].team1Score + testScoreboard.games[i].team2Score);
            }
            Assert.True(true);

        }
    }
}