using System;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.GameController {
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
        /// Numer of rounds played
        /// </summary>
        int Round { get; }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        void NewGame(IPlayer player1, IPlayer player2);

        /// <summary>
        /// Tries to apply a turn of phase 1
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="activePlayer"></param>
        /// <returns></returns>
        bool DoTurn(Coordinate coordinate, IPlayer activePlayer);

        /// <summary>
        /// Tries to apply a turn of phase 2 and phase 3
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        bool DoTurn(Move move);
    }
}