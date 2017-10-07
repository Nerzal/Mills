namespace Mills.ConsoleClient.Rules {
    /// <summary>
    /// Used to validate GameRules
    /// </summary>
    public class Validator : IRuleValidator, IMovementValidator {
        /// <inheritdoc />
        public IRuleSet Rules { get; }

        /// <inheritdoc />
        public Validator(IRuleSet rules) {
            this.Rules = rules;
        }

        /// <inheritdoc />
        public bool ValidateMovement(Move move) {
            foreach (ValidationRule<Move> movementRules in this.Rules.MoveValidationRules) {
                if (!movementRules.Evaluate(move)) {
                    return false;
                }
            }
            return true;
        }
    }
}