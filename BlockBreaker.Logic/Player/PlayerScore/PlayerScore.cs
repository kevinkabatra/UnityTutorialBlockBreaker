namespace BlockBreaker.Logic.Player.PlayerScore
{
    using Kabatra.Common.Singleton;

    /// <inheritdoc/>
    public class PlayerScore : SingletonBase<PlayerScore>, IPlayerScore
    {
        private int score;

        /// <inheritdoc/>
        public virtual void AddToScore(int points = 1)
        {
            score += points;
        }

        /// <inheritdoc/>
        public int GetScore()
        {
            return score;
        }

        /// <inheritdoc/>
        public void ResetScore()
        {
            score = 0;
        }
    }
}
