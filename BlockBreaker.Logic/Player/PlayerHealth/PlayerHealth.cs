namespace BlockBreaker.Logic.Player.PlayerHealth
{
    using Kabatra.Common.Singleton;

    public class PlayerHealth : SingletonBase<PlayerHealth>, IPlayerHealth
    {
        private const int defaultPlayerHealth = 3;
        private int playerHealth;

        public PlayerHealth()
        {
            playerHealth = defaultPlayerHealth;
        }

        /// <inheritdoc/>
        public void AddDamage(int damage = 1)
        {
            playerHealth -= damage;
        }

        /// <inheritdoc/>
        public int GetHealth()
        {
            return playerHealth;
        }

        /// <inheritdoc/>
        public void ResetHealth()
        {
            playerHealth = defaultPlayerHealth;
        }
    }
}
