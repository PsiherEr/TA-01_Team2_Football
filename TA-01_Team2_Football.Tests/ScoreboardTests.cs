namespace TA_01_Team2_Football.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Scoreboard scoreboard = new Scoreboard();

            if (scoreboard.input() == null)
            {
                Assert.True(false);
            }

            //Act
            int CountGames = scoreboard.games.Count();
            for (int i = 0; i < CountGames; i++)
            {
                if (scoreboard.games[i].team1 == scoreboard.games[i].team2)
                {
                    Assert.True(false);
                }

                if (scoreboard.games[i].team1 == null || scoreboard.games[i].team2 == null)
                {
                    Assert.True(false);
                }

                for (int j = 0; j < CountGames; j++)
                {
                    if (i != j)
                    {
                        if (scoreboard.games[j].team1 == scoreboard.games[i].team1 && scoreboard.games[j].team2 == scoreboard.games[i].team2)
                        {
                            Assert.True(false);
                        }
                    }
 
                }
            }

            //Assert
            Assert.True(true);


        }
    }
}