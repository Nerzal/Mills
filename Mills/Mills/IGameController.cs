using System;

namespace Mills.ConsoleClient {
    /// <summary>
    /// Controls the game
    /// </summary>
    public interface IGameController {
        /// <summary>
        /// Invoked when a player has won
        /// </summary>
        event Action<IPlayer> PlayerWon;

        /// <summary>
        /// The player that has it's turn
        /// </summary>
        IPlayer ActivePlayer { get; }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        void NewGame(IPlayer player1, IPlayer player2);

        /// <summary>
        /// Tries to apply a turn
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        bool DoTurn(Move move);
    }
}