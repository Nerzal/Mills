using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Markerinterface
    /// </summary>
    public interface IMillRuleEvaluator : IRuleEvaluator, IMovementEvaluator, IGameOverEvaluator, IGamePhaseEvaluator {
        /// <summary>
        /// Board Analyzer
        /// </summary>
        IBoardAnalyzer BoardAnalyzer { get; }
    }
}