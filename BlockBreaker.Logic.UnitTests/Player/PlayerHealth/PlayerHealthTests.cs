namespace BlockBreaker.Logic.UnitTests.Player.PlayerHealth
{
    using BlockBreaker.Logic.Player.PlayerHealth;
    using BlockBreaker.Logic.UnitTests.Common;
    using Xunit;

    public class PlayerHealthTests : SingletonTester<PlayerHealth>
    {
        [Fact]
        public void CanGetPlayerHealth()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var healthValue = playerHealth.GetPlayerHealth();

            Assert.NotEqual(0, healthValue);
        }

        [Fact]
        public void CanAddDamage()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetPlayerHealth();

            playerHealth.AddDamage();
            var updatedHealthValue = playerHealth.GetPlayerHealth();

            Assert.Equal(updatedHealthValue, originalHealthValue - 1);
        }

        [Fact]
        public void CanAddSpecifiedDamage()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetPlayerHealth();

            var damageToAdd = 2;
            playerHealth.AddDamage(damageToAdd);
            var updatedHealthValue = playerHealth.GetPlayerHealth();

            Assert.Equal(updatedHealthValue, originalHealthValue - damageToAdd);
        }

        [Fact]
        public void CanIncreasePlayerHealth()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetPlayerHealth();
            var expectedHealthValue = originalHealthValue + 1;

            playerHealth.IncreasePlayerHealth();

            Assert.Equal(expectedHealthValue, playerHealth.GetPlayerHealth());
        }

        [Fact]
        public void CanResetHealth()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetPlayerHealth();
            
            playerHealth.AddDamage();
            playerHealth.ResetPlayerHealth();

            Assert.Equal(originalHealthValue, playerHealth.GetPlayerHealth());
        }
    }
}
