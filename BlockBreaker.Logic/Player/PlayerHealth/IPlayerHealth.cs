﻿namespace BlockBreaker.Logic.Player.PlayerHealth
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
        int GetHealth();

        /// <summary>
        ///     Resets the player's health to its original value.
        /// </summary>
        void ResetHealth();
    }
}