using System.Linq;

namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Used to validate GameRules
    /// </summary>
    public class Validator : IMillRuleValidator {
        /// <inheritdoc />
        public IRuleSet Rules { get; }

        /// <inheritdoc />
        public Validator(IRuleSet rules) {
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