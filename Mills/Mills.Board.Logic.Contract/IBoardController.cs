using Mills.Game.Data.Contract;

namespace Mills.Board.Logic.Contract {
    /// <summary>
    /// Controls the board
    /// </summary>
    public interface IBoardController {
        /// <summary>
        /// The board to control
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        /// Initializes the board with the default state
        /// </summary>
        void Initialize();

        /// <summary>
        /// Occupy a coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="player"></param>
        /// <returns>true if the move was valid</returns>
        bool Set(Coordinate coordinate, IPlayer player);

        /// <summary>
        /// Release a coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="activePlayer"></param>
        /// <param name="otherPlayer"></param>
        /// <returns>true if the move was valid</returns>
        bool Unset(Coordinate coordinate, IPlayer activePlayer, IPlayer otherPlayer);

        /// <summary>
        /// Applies a move onto the board
        /// </summary>
        /// <param name="move"></param>
        /// <returns>true if the move was valid</returns>
        bool Move(Move move);

        /// <summary>
        /// Jump from Coordinate to Coordinate
        /// </summary>
        /// <param name="move"></param>
        /// <returns>true if the move was valid</returns>
        bool Jump(Move move);
    }
}