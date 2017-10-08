using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;

namespace Mills.ConsoleClient.Rules.GameOver {
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