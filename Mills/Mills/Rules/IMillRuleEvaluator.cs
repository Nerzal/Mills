using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Markerinterface
    /// </summary>
    public interface IMillRuleEvaluator : IRuleEvaluator, IMovementEvaluator, IGameOverEvaluator, IGamePhaseEvaluator {
        /// <summary>
        /// BoardAnalyzer Analyzer
        /// </summary>
        IBoardAnalyzer BoardAnalyzer { get; }
    }
}