using Mills.Board.Logic.Contract;

namespace Mills.Rules.Contract {
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