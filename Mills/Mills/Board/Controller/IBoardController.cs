using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.ConsoleClient.Board.Controller {
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
        /// Applies a move onto the board
        /// </summary>
        /// <param name="move"></param>
        void Move(Move move);

        /// <summary>
        /// Occupy a coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="player"></param>
        bool Set(Coordinate coordinate, IPlayer player);

        /// <summary>
        /// Jump from Coordinate to Coordinate
        /// </summary>
        /// <param name="move"></param>
        void Jump(Move move);
    }
}