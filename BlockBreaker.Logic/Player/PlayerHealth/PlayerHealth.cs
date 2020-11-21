namespace BlockBreaker.Logic.Player.PlayerHealth
{
    using Kabatra.Common.Singleton;

    public class PlayerHealth : SingletonBase<PlayerHealth>, IPlayerHealth
    {
        private int playerHealth = 3;

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
    }
}
