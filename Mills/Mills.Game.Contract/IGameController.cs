using System;
using Mills.Game.Data.Contract;

namespace Mills.Game.Contract {
    /// <summary>
    /// Controls the game
    /// </summary>
    public interface IGameController {
        /// <summary>
        /// Invoked when a player has won
        /// </summary>
        event Action<IPlayer> PlayerWon;

        /// <summary>
        /// Invoked when a mill was completed this round
        /// </summary>
        event Action MillCompleted;

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
        bool Set(Coordinate coordinate, IPlayer activePlayer);

        /// <summary>
        /// Tries to apply a turn of phase 2 and phase 3
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        bool DoTurn(Move move);

        /// <summary>
        /// Tries to apply an unset on the board
        /// Has to be called after a mill was found
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="activePlayer"></param>
        /// <returns></returns>
        bool Unset(Coordinate coordinate, IPlayer activePlayer);
    }
}