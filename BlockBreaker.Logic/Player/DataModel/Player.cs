namespace BlockBreaker.Logic.Player.DataModel
{
    using BlockBreaker.Logic.Player.PlayerHealth;
    using BlockBreaker.Logic.Player.PlayerScore;
    using Kabatra.Common.Singleton;

    /// <summary>
    ///     The player.
    /// </summary>
    public class Player : SingletonBase<Player>
    {
        public PlayerHealth Health;
        public PlayerScore Score;

        /// <summary>
        ///     Gets or creates an instance of the Player.
        /// </summary>
        /// <returns></returns>
        public static new Player GetOrCreateInstance()
        {
            var player = SingletonBase<Player>.GetOrCreateInstance();
            player.Health = PlayerHealth.GetOrCreateInstance();
            player.Score = PlayerScore.GetOrCreateInstance();

            return player;
        }
    }
}
