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
            var healthValue = playerHealth.GetHealth();

            Assert.NotEqual(0, healthValue);
        }

        [Fact]
        public void CanAddDamage()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetHealth();

            playerHealth.AddDamage();
            var updatedHealthValue = playerHealth.GetHealth();

            Assert.Equal(updatedHealthValue, originalHealthValue - 1);
        }

        [Fact]
        public void CanAddSpecifiedDamage()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var originalHealthValue = playerHealth.GetHealth();

            var damageToAdd = 2;
            playerHealth.AddDamage(damageToAdd);
            var updatedHealthValue = playerHealth.GetHealth();

            Assert.Equal(updatedHealthValue, originalHealthValue - damageToAdd);
        }

        [Fact]
        public void CanResetPlayerHealth()
        {
            var playerHealth = PlayerHealth.GetOrCreateInstance();
            var defaultPlayerHealth = playerHealth.GetHealth();

            playerHealth.AddDamage();
            playerHealth.ResetHealth();

            Assert.Equal(defaultPlayerHealth, playerHealth.GetHealth());
        }
    }
}
