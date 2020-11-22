namespace BlockBreaker.Logic.Player.PlayerScore
{
    /// <summary>
    ///     Player Score.
    /// </summary>
    public interface IPlayerScore
    {
        /// <summary>
        ///     Adds the specified number of points to the score.
        /// </summary>
        /// <param name="points"></param>
        void AddToScore(int points);

        /// <summary>
        ///     Returns the current value of the score.
        /// </summary>
        /// <returns></returns>
        int GetScore();

        /// <summary>
        ///     Resets the score to 0.
        /// </summary>
        void ResetScore();
    }
}
