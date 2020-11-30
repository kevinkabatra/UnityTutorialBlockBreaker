namespace BlockBreaker.Logic.Player.PlayerHealth
{
    using Kabatra.Common.Singleton;

    public class PlayerHealth : SingletonBase<PlayerHealth>, IPlayerHealth
    {
        private const int maxPlayerHealth = 15;
        private int defaultPlayerHealth = 3;
        private int playerHealth;

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlayerHealth()
        {
            playerHealth =  defaultPlayerHealth;
        }

        /// <inheritdoc/>
        public void AddDamage(int damage = 1)
        {
            playerHealth -= damage;
        }

        /// <inheritdoc/>
        public int GetPlayerHealth()
        {
            return playerHealth;
        }

        /// <inheritdoc/>
        public void IncreasePlayerHealth()
        {
            if((defaultPlayerHealth + 1) > maxPlayerHealth)
            {
                return;
            }

            defaultPlayerHealth++;
            playerHealth = defaultPlayerHealth;
        }

        /// <inheritdoc/>
        public void ResetPlayerHealth()
        {
            playerHealth = defaultPlayerHealth;
        }
    }
}
