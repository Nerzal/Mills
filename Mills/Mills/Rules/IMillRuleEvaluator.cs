using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Markerinterface
    /// </summary>
    public interface IMillRuleEvaluator : IRuleValidator, IMovementValidator, IGameOverValidator {
    }
}