﻿namespace Mills.Game.Data.Contract {
    /// <summary>
    /// Holds every move that happened during a single game
    /// </summary>
    public interface IHistory {
        /// <summary>
        /// Adds a move onto the history
        /// </summary>
        /// <param name="move"></param>
        void Add(Move move);
    }
}