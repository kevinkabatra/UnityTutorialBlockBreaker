namespace BlockBreaker.Logic.Player.PlayerHealth
{
    /// <summary>
    ///     Player health.
    /// </summary>
    public interface IPlayerHealth
    {
        /// <summary>
        ///     Damages the player's health.
        /// </summary>
        /// <param name="damage"></param>
        void AddDamage(int damage);

        /// <summary>
        ///     Returns the player's health.
        /// </summary>
        /// <returns></returns>
        int GetPlayerHealth();

        /// <summary>
        ///     Increases the player's health up to the hard coded max.
        /// </summary>
        void IncreasePlayerHealth();

        /// <summary>
        ///     Resets the player's health to the default value.
        /// </summary>
        void ResetPlayerHealth();
    }
}
