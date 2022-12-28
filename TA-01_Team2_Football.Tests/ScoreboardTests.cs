namespace TA_01_Team2_Football.Tests
{
    public class ScoreboardTests
    {
        [Fact]
        public void Input_EnglandUkraine_ThrowsException()
        {
            //Arrange
            Scoreboard scoreboard = new Scoreboard();

            Assert.Throws<ArgumentException>(() => scoreboard.input("", "England"));                                            
        }

        [Fact]
        public void Input_UkraineEngland_ShouldAddGameToScoreboard ()
        {
            var team1 = "Ukraine";
            var team2 = "England";

            Scoreboard scoreboard = new Scoreboard();
            var count = scoreboard.games.Count();
            scoreboard.input(team1, team2);
            Assert.Equal(count + 1, scoreboard.games.Count());
        }

        [Fact]
        public void Input_TheSameTeamNames_Exception()
        {
            var team1 = "Ukraine";
            var team2 = "Ukraine";

            Scoreboard scoreboard = new Scoreboard();

            Assert.Throws<ArgumentException>(() => scoreboard.input(team1, team2));
        }

        [Fact]
        public void Input_UnwantedSymbolsInTeamName_Exception()
        {
            var team1 = "Ukrai-ne";
            var team2 = "England";

            Scoreboard scoreboard = new Scoreboard();

            Assert.Throws<ArgumentException>(() => scoreboard.input(team1, team2));
        }

        [Fact]
        public void Input_TeamIsAlreadyPlaying_Exception()
        {
            var team1 = "Ukraine";
            var team2 = "England";

            var team3 = "Ukraine";
            var team4 = "Spain";

            Scoreboard scoreboard = new Scoreboard();
            scoreboard.input(team1, team2);

            Assert.Throws<ArgumentException>(() => scoreboard.input(team3, team4));
        }
    }
}

/*
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
Assert.True(true);*/