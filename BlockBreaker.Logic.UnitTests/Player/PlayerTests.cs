namespace BlockBreaker.Logic.UnitTests.Player
{
    using BlockBreaker.Logic.Player.DataModel;
    using BlockBreaker.Logic.UnitTests.Common;
    using Xunit;

    public class PlayerTests : SingletonTester<Player>
    {
        [Fact]
        public void CanCreatePlayer()
        {
            var player = Player.GetOrCreateInstance();
            Assert.NotNull(player);
        }

        [Fact]
        public void CanCreatePlayerWithHealth()
        {
            var player = Player.GetOrCreateInstance();
            Assert.NotNull(player.Health);
        }

        [Fact]
        public void CanCreatePlayerWithScore()
        {
            var player = Player.GetOrCreateInstance();
            Assert.NotNull(player.Score);
        }
    }
}
