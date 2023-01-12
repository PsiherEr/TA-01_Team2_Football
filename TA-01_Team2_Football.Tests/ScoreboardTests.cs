namespace TA_01_Team2_Football.Tests
{
    class Compare : IEqualityComparer<Game>
    {
        public bool Equals(Game game1, Game game2)
        {
            if (GetHashCode(game1) == GetHashCode(game2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetHashCode(Game g)
        {
            return (g.team1Score * 33 + 1) + (g.team2Score * 11 + 2);
        }
    }
    public class ScoreboardTests
    {
        [Fact]
        public void TestSummary()
        {
            //Arrange
            Scoreboard scoreboard1 = new Scoreboard();
            scoreboard1.games = new List<Game>
            {
                new Game("America", "Ukraine", 0, 2),
                new Game("Kazahstan", "Alzhir", 3, 1),
                new Game("France", "Argentina", 5, 3),
                new Game("Brazilia", "Argentina", 2, 2),
                new Game("Urugvay", "Canada", 0, 0),
                new Game("Japan", "Moldova", 0, 1)
            };
            var expected = new List<Game>
            {
                new Game("France", "Argentina", 5, 3),
                new Game("Kazahstan", "Alzhir", 3, 1),
                new Game("Brazilia", "Argentina", 2, 2),
                new Game("America", "Ukraine", 0, 2),
                new Game("Japan", "Moldova", 0, 1),
                new Game("Urugvay", "Canada", 0, 0)
            };
            //Act
            var actual = scoreboard1.games;
            actual = scoreboard1.sortScoreBoard();

            //Assert
            Compare compare = new Compare();
            Assert.Equal(expected, actual, compare);
        }
        [Theory]
        [InlineData("France", null, 5, 3)]
        [InlineData(null, "Argentina", 5, 3)]
        [InlineData(null, null, 5, 3)]
        public void TestNullGameTeamName(string team1, string team2, int team1Score, int team2Score)
        {
            Assert.Throws<NullReferenceException>(() => new Game(team1, team2, team1Score, team2Score));
        }
        [Theory]
        [InlineData("France", "Argentina", -1, 3)]
        [InlineData("France", "Argentina", 5, -5)]
        [InlineData("France", "Argentina", -3, -4)]
        public void TestNegativeGameTeamScore(string team1, string team2, int team1Score, int team2Score)
        {
            Assert.Throws<InvalidOperationException>(() => new Game(team1, team2, team1Score, team2Score));
        }
        [Fact]
        public void TestNullScoreboardList()
        {
            Scoreboard scoreboard = new Scoreboard();
            Assert.Throws<IndexOutOfRangeException>(() => scoreboard.sortScoreBoard());
        }
        [Fact]
        public void TestScoreboardListWithOneElement()
        {
            Scoreboard scoreboard2 = new Scoreboard();
            scoreboard2.games = new List<Game>
            {
                new Game("France", "Argentina", 1, 3)
            };
            Assert.Throws<IndexOutOfRangeException>(() => scoreboard2.sortScoreBoard());
        }
    }
}