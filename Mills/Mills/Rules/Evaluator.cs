using System.Linq;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Used to validate GameRules
    /// </summary>
    public class Evaluator : IMillRuleEvaluator {
        /// <inheritdoc />
        public IRuleSet Rules { get; }

        /// <inheritdoc />
        public Evaluator(IRuleSet rules) {
            this.Rules = rules;
        }

        /// <inheritdoc />
        public bool ValidateMovement(Move move) {
            return this.Rules.MoveValidationRules.All(movementRules => movementRules.Evaluate(move));
        }

        /// <inheritdoc />
        public bool IsGameOver(IBoard board) {
            return this.Rules.GameOverRules.All(gameOverRules => gameOverRules.Evaluate(board));
        }
    }
}