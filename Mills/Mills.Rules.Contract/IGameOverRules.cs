using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;

namespace Mills.Rules.Contract {
    /// <summary>
    /// ENumerable of GameOverRules
    /// </summary>
    public interface IGameOverRules : IBaseRules<IBoard> {
        /// <summary>
        /// BoardAnalyzer Analyzer
        /// </summary>
        IBoardAnalyzer BoardAnalyzer { get; }
    }
}