using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Rules.GameOver;

namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// Extends <see cref="IBaseRules{Move}"/>
    /// Holds rules for movement
    /// </summary>
    public interface IMovementRules : IBaseRules<Move> {
        /// <summary>
        /// The board
        /// </summary>
        IBoard Board { get; }
    }
}