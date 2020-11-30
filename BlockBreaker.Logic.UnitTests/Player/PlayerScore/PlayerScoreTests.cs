namespace BlockBreaker.Logic.UnitTests.Player.PlayerScore
{
    using BlockBreaker.Logic.Player.PlayerScore;
    using BlockBreaker.Logic.UnitTests.Common;
    using Xunit;

    public class PlayerScoreTests : SingletonTester<PlayerScore>
    {
        [Fact]
        public void CanAddToScore()
        {
            var playerScore = PlayerScore.GetOrCreateInstance();
            var initialScore = playerScore.GetScore();

            playerScore.AddToScore();
            var updatedScore = playerScore.GetScore();

            Assert.Equal(updatedScore, initialScore + 1);
        }

        [Fact]
        public void CanAddSpecifiedPointsToScore()
        {
            var playerScore = PlayerScore.GetOrCreateInstance();
            var initialScore = playerScore.GetScore();

            var pointsToAdd = 2;
            playerScore.AddToScore(pointsToAdd);
            var updatedScore = playerScore.GetScore();

            Assert.Equal(updatedScore, initialScore + pointsToAdd);
        }

        [Fact]
        public void CanResetScore()
        {
            var playerScore = PlayerScore.GetOrCreateInstance();
            var initialScore = playerScore.GetScore();

            playerScore.AddToScore();
            playerScore.ResetScore();

            var resetScore = playerScore.GetScore();

            Assert.Equal(initialScore, resetScore);
        }
    }
}
