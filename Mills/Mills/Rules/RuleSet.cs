using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules {
    public class RuleSet : IRuleSet {
        public IMovementRules MoveValidationRules { get; }
        public IGameOverRules GameOverRules { get; }

        public RuleSet(
            IMovementRules moveValidationRules,
            IGameOverRules gameOverRules) {
            this.MoveValidationRules = moveValidationRules;
            this.GameOverRules = gameOverRules;
        }
    }
}