using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Board {
    /// <summary>
    /// Controls the board
    /// </summary>
    public interface IBoardController : IBoardAnalyzer {
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
    }
}