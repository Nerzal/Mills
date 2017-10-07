using Mills.ConsoleClient.Board;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// ENumerable of GameOverRules
    /// </summary>
    public interface IGameOverRules : IBaseRules<IBoard> {
        /// <summary>
        /// Board Analyzer
        /// </summary>
        IBoardAnalyzer BoardAnalyzer { get; }
    }
}