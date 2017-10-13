using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;

namespace Mills.Rules.Contract {
    /// <summary>
    /// Extends <see cref="IBaseRules{Move}"/>
    /// Holds rules for movement
    /// </summary>
    public interface IMovementRules : IBaseRules<Move> {
        /// <summary>
        /// The board
        /// </summary>
        IBoardAnalyzer BoardAnalyzer { get; }
    }
}