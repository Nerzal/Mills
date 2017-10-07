using System.Collections.Generic;
using Mills.ConsoleClient.Rules;
using Mills.ConsoleClient.Rules.GameOver;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient {
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